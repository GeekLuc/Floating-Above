using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SnowStorm : MonoBehaviour
{
    [SerializeField] Volume _globalVolume;
    [SerializeField] ParticleSystem _fastSnow;
    [SerializeField] float DurationStorm = 5f;
    [SerializeField] float IntervalStorm = 5f;
    Vignette _vignette;
    float _vignetteIntensityBase = 0.2f;
    float _vignetteIntensityStorm = 0.8f;
    bool _storm = false;
    float _speed = 0.01f;
    float _fullTextureValue = 1f;
    float _noTextureValue = 0f;
    float _currentTextureValue;
    float _currentSkyValue;

    void Start()
    {
        _currentSkyValue = 0f;
        Shader.SetGlobalFloat("_ChangeSkyColour", _currentSkyValue);
        _currentTextureValue = 0f;
        Shader.SetGlobalFloat("_SwitchTexture", _currentTextureValue);
        _globalVolume.profile.TryGet(out Vignette _vignette);
        if (_globalVolume.profile.TryGet(out Vignette vignette))
        {
            _vignette.intensity.value = _vignetteIntensityBase;
        }
        _storm = false;

        // Appel de la méthode pour démarrer l'intervalle de tempête
        StartCoroutine(StartStormInterval());
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_storm)
            {
                _storm = false;
            }
            else
            {
                _storm = true;
            }
        }*/

        if (_storm)
        {
            _fastSnow.Emit(1);
            _fastSnow.Play();
            StartCoroutine(StormOn());
        }
        else
        {
            StartCoroutine(StormOff());
        }
    }

    IEnumerator StormOn()
    {
        _globalVolume.profile.TryGet(out Vignette _vignette);
        if (_globalVolume.profile.TryGet(out Vignette vignette))
        {
            while (_vignette.intensity.value != _vignetteIntensityStorm)
            {
                _vignette.intensity.value = Mathf.MoveTowards(_vignette.intensity.value, _vignetteIntensityStorm, _speed * Time.deltaTime);
                _currentTextureValue = Mathf.MoveTowards(_currentTextureValue, _fullTextureValue, _speed * Time.deltaTime);
                Shader.SetGlobalFloat("_SwitchTexture", _currentTextureValue);
                Shader.SetGlobalFloat("_ChangeSkyColour", _currentTextureValue);

                yield return null;
            }
        }
    }
    IEnumerator StormOff()
    {
        _globalVolume.profile.TryGet(out Vignette _vignette);
        if (_globalVolume.profile.TryGet(out Vignette vignette))
        {
            while (_vignette.intensity.value != _vignetteIntensityBase)
            {
                _vignette.intensity.value = Mathf.MoveTowards(_vignette.intensity.value, _vignetteIntensityBase, _speed * Time.deltaTime);
                _currentTextureValue = Mathf.MoveTowards(_currentTextureValue, _noTextureValue, _speed * Time.deltaTime);
                Shader.SetGlobalFloat("_SwitchTexture", _currentTextureValue);
                Shader.SetGlobalFloat("_ChangeSkyColour", _currentTextureValue);

                yield return null;
            }
            _fastSnow.Stop();
        }
    }

    IEnumerator StartStormInterval(){
        yield return new WaitForSeconds(IntervalStorm);
        _storm = true;
        StartCoroutine(StartStormDuration());
    }

    IEnumerator StartStormDuration()
    {
        yield return new WaitForSeconds(DurationStorm);
        _storm = false;
        StartCoroutine(StartStormInterval());
    }
}
