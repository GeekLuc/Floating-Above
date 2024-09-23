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
            Debug.LogError("Le script LifeBar n'est pas trouv� sur l'objet LifeBar.");
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
                Debug.LogError("Le script LifeBar n'est pas trouv� sur l'objet: " + lifeBarObject.name);
            }
            return lb;
        }
        else
        {
            Debug.LogError("L'objet LifeBar n'est pas trouv� dans la sc�ne.");
            return null;
        }
    }

    private Death FindDeathScript()
    { // Modifiez cette m�thode
        GameObject groundObject = GameObject.Find("polySurface4"); // Recherchez l'objet par son nom
        if (groundObject != null)
        {
            Death ds = groundObject.GetComponent<Death>();
            if (ds == null)
            {
                Debug.LogError("Le script Death n'est pas trouv� sur l'objet: " + groundObject.name);
            }
            return ds;
        }
        else
        {
            Debug.LogError("L'objet polySurface4 n'est pas trouv� dans la sc�ne.");
            return null;
        }
    }

    private void PlayDamageSound()
    {
        // Int�gration des sons
        // TODO: Ajouter le code pour jouer un son de dommage
    }

    private void PlayDamageVFX()
    {
        // Int�gration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de dommage
    }
}
