// Rougefort Luca B3JV1 Prog
// CheckPoint.cs
// GameJam rentr�e 2024-2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour{
    private bool isUnlocked = false;

    public void CheckIfPlayerPassed(GameObject player){
        if (HasPlayerPassed(player)){
            UnlockCheckpoint();
        }
    }

    private bool HasPlayerPassed(GameObject player){
        return player.transform.position.x > transform.position.x;
    }

    private void UnlockCheckpoint(){
        isUnlocked = true;
        PlayCheckpointUnlockSound();
        PlayCheckpointUnlockVFX();
    }

    public bool IsUnlocked(){
        return isUnlocked;
    }

    public Vector3 GetPosition(){
        return transform.position;
    }

    private void PlayCheckpointUnlockSound(){
        // Int�gration des sons
        // TODO: Ajouter le code pour jouer un son de d�verrouillage du checkpoint
    }

    private void PlayCheckpointUnlockVFX(){
        // Int�gration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de d�verrouillage du checkpoint
    }
}


