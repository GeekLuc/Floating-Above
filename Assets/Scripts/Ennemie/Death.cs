// Rougefort Luca B3JV1 Prog
// Death.cs
// GameJam rentrée 2024-2025

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Death : MonoBehaviour{
    private LifeBar lifeBar;
    public GameObject player; // Référence au joueur
    public CheckPoint[] checkpoints; // Tableau de checkpoints

    void Start(){
        InitializeLifeBar();
    }

    void Update(){
        CheckPlayerPassedCheckpoints();
    }

    void OnTriggerEnter(Collider collision){
        if (collision.gameObject.CompareTag("Player")){
            HandlePlayerCollision();
        }
    }

    private void InitializeLifeBar(){
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

    private void CheckPlayerPassedCheckpoints(){
        foreach (var checkpoint in checkpoints){
            if (checkpoint != null){
                checkpoint.CheckIfPlayerPassed(player);
            }
        }
    }

    private void HandlePlayerCollision(){
        if (lifeBar != null){
            lifeBar.Damage();
            PlayDamageSound();
            PlayDamageVFX();

            if (lifeBar.HasLivesLeft()){
                TeleportPlayerToCheckpoint();
            }
        }else{
            Debug.LogError("Le script LifeBar n'est pas trouvé sur l'objet LifeBar.");
        }
    }

    public void TeleportPlayerToCheckpoint(){
        if (player != null && checkpoints.Length > 0){
            Vector3 teleportPosition = GetLastUnlockedCheckpointPosition();
            player.transform.position = teleportPosition;
        }else{
            Debug.LogError("Le joueur ou les checkpoints ne sont pas définis.");
        }
    }

    private Vector3 GetLastUnlockedCheckpointPosition(){
        Vector3 teleportPosition = checkpoints[0].GetPosition();

        foreach (var checkpoint in checkpoints){
            if (checkpoint != null && checkpoint.IsUnlocked()){
                teleportPosition = checkpoint.GetPosition();
            }
        }
        return teleportPosition;
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

