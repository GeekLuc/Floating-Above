// Rougefort Luca B3JV1 Prog
// EndLevel.cs
// GameJam rentr�e 2024-2025
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour{
    public GameObject endLevelObject; // L'objet de fin de niveau
    public Ballon playerBallon; // R�f�rence au script Ballon du joueur

    void Update(){
        if (playerBallon.transform.position.x > endLevelObject.transform.position.x){
            playerBallon.StopFlying();
            if (playerBallon.fallCoroutine == null){
                playerBallon.fallCoroutine = StartCoroutine(playerBallon.FallVertically());
            }

            //Mettre l'anim/cinematique de fin, aller vers le chalet, plus de pr�cision ?


            Debug.Log("FIN WIN");

            SceneManager.LoadScene("WinScene");
        }
    }
}
