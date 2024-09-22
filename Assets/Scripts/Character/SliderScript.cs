// Rougefort Luca B3JV1 Prog
// SliderScript.cs
// GameJam rentrée 2024-2025

using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour{
    public Ballon ballon; // Référence au script Ballon
    public Slider scaleSlider; // Référence à la barre de défilement UI

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
        // Intégration des sons
        // TODO: Ajouter le code pour jouer un son de mise à jour du slider
    }

    private void PlaySliderUpdateVFX(){
        // Intégration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de mise à jour du slider
    }
}
