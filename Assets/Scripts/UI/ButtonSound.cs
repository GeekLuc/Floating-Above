using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    [SerializeField] AudioSource _buttonSFX;
    [SerializeField] AudioSource _backSFX;
    [SerializeField] AudioSource _moveSFX;
    
    public void PlayBackSound()
    {
        _backSFX.Play();
    }
    public void PlayButtonSound()
    {
        _buttonSFX.Play();
    }

    public void PlayMoveSound()
    {
        _moveSFX.Play();
    }
}
