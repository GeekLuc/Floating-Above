// Rougefort Luca B3JV1 Prog
// Dammage.cs
// GameJam rentr�e 2024-2025

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
            Debug.LogError("Le script LifeBar n'est pas trouv� sur l'objet LifeBar.");
        }
    }

    private LifeBar FindLifeBar(){
        GameObject lifeBarObject = GameObject.Find("LifeBar");
        if (lifeBarObject != null){
            LifeBar lb = lifeBarObject.GetComponent<LifeBar>();
            if (lb == null){
                Debug.LogError("Le script LifeBar n'est pas trouv� sur l'objet: " + lifeBarObject.name);
            }
            return lb;
        }else{
            Debug.LogError("L'objet LifeBar n'est pas trouv� dans la sc�ne.");
            return null;
        }
    }

    private void PlayDamageSound(){
        // Int�gration des sons
        // TODO: Ajouter le code pour jouer un son de dommage
    }

    private void PlayDamageVFX(){
        // Int�gration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de dommage
    }
}

