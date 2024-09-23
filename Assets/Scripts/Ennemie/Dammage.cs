using UnityEngine;

public class Dammage : MonoBehaviour
{
    private LifeBar lifeBar;
    private Death deathScript; // Ajoutez cette ligne

    void Start()
    {
        lifeBar = FindLifeBar();
        deathScript = FindDeathScript(); // Ajoutez cette ligne
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerCollision();
        }
    }

    private void HandlePlayerCollision()
    {
        if (lifeBar != null)
        {
            lifeBar.Damage();
            PlayDamageSound();
            PlayDamageVFX();
            if (lifeBar.HasLivesLeft())
            {
                //ICI
                deathScript.TeleportPlayerToCheckpoint(); // Ajoutez cette ligne
            }
        }
        else
        {
            Debug.LogError("Le script LifeBar n'est pas trouvé sur l'objet LifeBar.");
        }
    }

    private LifeBar FindLifeBar()
    {
        GameObject lifeBarObject = GameObject.Find("LifeBar");
        if (lifeBarObject != null)
        {
            LifeBar lb = lifeBarObject.GetComponent<LifeBar>();
            if (lb == null)
            {
                Debug.LogError("Le script LifeBar n'est pas trouvé sur l'objet: " + lifeBarObject.name);
            }
            return lb;
        }
        else
        {
            Debug.LogError("L'objet LifeBar n'est pas trouvé dans la scène.");
            return null;
        }
    }

    private Death FindDeathScript()
    { // Modifiez cette méthode
        GameObject groundObject = GameObject.Find("polySurface4"); // Recherchez l'objet par son nom
        if (groundObject != null)
        {
            Death ds = groundObject.GetComponent<Death>();
            if (ds == null)
            {
                Debug.LogError("Le script Death n'est pas trouvé sur l'objet: " + groundObject.name);
            }
            return ds;
        }
        else
        {
            Debug.LogError("L'objet polySurface4 n'est pas trouvé dans la scène.");
            return null;
        }
    }

    private void PlayDamageSound()
    {
        // Intégration des sons
        // TODO: Ajouter le code pour jouer un son de dommage
    }

    private void PlayDamageVFX()
    {
        // Intégration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de dommage
    }
}
