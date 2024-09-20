using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
    GameJam 2024-2025 - Team 3
    SliderScript.cs
    Rougefort Luca B3JV1
*/

public class Death : MonoBehaviour{
    private LifeBar lifeBar;

    void Start(){
        GameObject lifeBarObject = GameObject.Find("LifeBar");
        if (lifeBarObject != null){
            lifeBar = lifeBarObject.GetComponent<LifeBar>();
            if (lifeBar == null){
                Debug.LogError("Le script LifeBar n'est pas trouvé sur l'objet: " + lifeBarObject.name);
            }
        }else{
            Debug.LogError("L'objet LifeBar n'est pas trouvé dans la scène.");
        }
    }
    void OnTriggerEnter(Collider collision){
        if (collision.gameObject.CompareTag("Player")){
            if (lifeBar != null){
                lifeBar.Death();
            }else{
                Debug.LogError("Le script LifeBar n'est pas trouvé sur l'objet LifeBar.");
            }
        }
    }
}
