// Rougefort Luca B3JV1 Prog
// Ventilo.cs
// GameJam rentrée 2024-2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilo : MonoBehaviour{
    public float pushForce = 10f; // Force de l'impulsion

    private void OnTriggerEnter(Collider other){
        if (IsPlayer(other)){
            HandlePlayerEnter();
        }
    }

    private void OnTriggerStay(Collider other){
        if (IsPlayer(other)){
            PushPlayer(other);
        }
    }

    private void OnTriggerExit(Collider other){
        if (IsPlayer(other)){
            HandlePlayerExit();
        }
    }

    private bool IsPlayer(Collider other){
        return other.CompareTag("Player");
    }

    private void HandlePlayerEnter(){
        Debug.Log("Le joueur est entré dans la zone de poussée du ventillo");
        PlayEnterSound();
        PlayEnterVFX();
    }

    private void PushPlayer(Collider player){
        Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
        if (playerRigidbody != null){
            player.transform.Translate(Vector3.right * pushForce * Time.deltaTime);
            Debug.Log("Le joueur est poussé");
        }else{
            Debug.Log("Le joueur n'a pas de Rigidbody");
        }
    }

    private void HandlePlayerExit(){
        Debug.Log("Le joueur a quitté la zone de poussée du ventillo");
        PlayExitSound();
        PlayExitVFX();
    }

    private void PlayEnterSound(){
        // Intégration des sons
        // TODO: Ajouter le code pour jouer un son à l'entrée de la zone de poussée
    }

    private void PlayEnterVFX(){
        // Intégration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel à l'entrée de la zone de poussée
    }

    private void PlayExitSound(){
        // Intégration des sons
        // TODO: Ajouter le code pour jouer un son à la sortie de la zone de poussée
    }

    private void PlayExitVFX(){
        // Intégration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel à la sortie de la zone de poussée
    }
}



