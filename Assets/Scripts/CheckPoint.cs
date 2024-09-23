using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool isUnlocked = false;
    [SerializeField] ParticleSystem _vfx;

    public void CheckIfPlayerPassed(GameObject player)
    {
        if (!isUnlocked && HasPlayerPassed(player))
        {
            UnlockCheckpoint();
        }
    }

    private bool HasPlayerPassed(GameObject player)
    {
        return player.transform.position.x > transform.position.x;
    }

    private void UnlockCheckpoint()
    {
        isUnlocked = true;
        PlayCheckpointUnlockSound();
        PlayCheckpointUnlockVFX();
    }

    public bool IsUnlocked()
    {
        return isUnlocked;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void PlayCheckpointUnlockSound()
    {
        // Int�gration des sons
        // TODO: Ajouter le code pour jouer un son de d�verrouillage du checkpoint
    }

    private void PlayCheckpointUnlockVFX()
    {
        _vfx.Play();
    }
}
