// Rougefort Luca B3JV1 Prog
// SliderScript.cs
// GameJam rentr�e 2024-2025

using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour{
    public Ballon ballon; // R�f�rence au script Ballon
    public Slider scaleSlider; // R�f�rence � la barre de d�filement UI

    void Update(){
        UpdateSlider();
    }

    private void UpdateSlider(){
        if (ballon != null && scaleSlider != null){
            float scaleProgress = CalculateScaleProgress();
            UpdateSliderValue(scaleProgress);
            ToggleSliderVisibility(scaleProgress);
        }
    }

    private float CalculateScaleProgress(){
        return Mathf.Clamp01(ballon.ScaleTime / ballon.inflateTime);
    }

    private void UpdateSliderValue(float scaleProgress){
        scaleSlider.value = scaleProgress;
    }

    private void ToggleSliderVisibility(float scaleProgress){
        scaleSlider.gameObject.SetActive(scaleProgress > 0);
    }

    private void PlaySliderUpdateSound(){
        // Int�gration des sons
        // TODO: Ajouter le code pour jouer un son de mise � jour du slider
    }

    private void PlaySliderUpdateVFX(){
        // Int�gration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de mise � jour du slider
    }
}
