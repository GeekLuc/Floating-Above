using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private bool isUnlocked = false;
    [SerializeField] ParticleSystem _vfx;
    [SerializeField] Renderer Drapeau; 

    private Color _defaultColor1;
    private Color _defaultColor2;
    private Color _defaultColor3;
    private Color _defaultColor4;

    private void Start()
    {
        // Sauvegarder les couleurs par défaut
        if (Drapeau != null) _defaultColor1 = Drapeau.material.color;

        UpdateCheckpointColor();
    }

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
        UpdateCheckpointColor();
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
        // Intégration des sons
        // TODO: Ajouter le code pour jouer un son de déverrouillage du checkpoint
    }

    private void PlayCheckpointUnlockVFX()
    {
        _vfx.Play();
    }

    private void UpdateCheckpointColor()
    {
        Color targetColor = isUnlocked ? Color.white : Color.black;

        if (Drapeau != null)
        {
            Drapeau.material.color = isUnlocked ? _defaultColor1 : targetColor;
        }
    }
}
