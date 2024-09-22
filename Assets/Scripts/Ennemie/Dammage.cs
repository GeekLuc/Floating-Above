// Rougefort Luca B3JV1 Prog
// Dammage.cs
// GameJam rentrée 2024-2025

using UnityEngine;

public class Dammage : MonoBehaviour{
    private LifeBar lifeBar;

    void Start(){
        lifeBar = FindLifeBar();
    }

    void OnTriggerEnter(Collider collision){
        if (collision.gameObject.CompareTag("Player")){
            HandlePlayerCollision();
        }
    }

    private void HandlePlayerCollision(){
        if (lifeBar != null){
            lifeBar.Damage();
            PlayDamageSound();
            PlayDamageVFX();
        }else{
            Debug.LogError("Le script LifeBar n'est pas trouvé sur l'objet LifeBar.");
        }
    }

    private LifeBar FindLifeBar(){
        GameObject lifeBarObject = GameObject.Find("LifeBar");
        if (lifeBarObject != null){
            LifeBar lb = lifeBarObject.GetComponent<LifeBar>();
            if (lb == null){
                Debug.LogError("Le script LifeBar n'est pas trouvé sur l'objet: " + lifeBarObject.name);
            }
            return lb;
        }else{
            Debug.LogError("L'objet LifeBar n'est pas trouvé dans la scène.");
            return null;
        }
    }

    private void PlayDamageSound(){
        // Intégration des sons
        // TODO: Ajouter le code pour jouer un son de dommage
    }

    private void PlayDamageVFX(){
        // Intégration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de dommage
    }
}

