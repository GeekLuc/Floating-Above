using UnityEngine;
using UnityEngine.UI;

/*
    GameJam 2024-2025 - Team 3
    SliderScript.cs
    Rougefort Luca B3JV1
*/
public class SliderScript : MonoBehaviour
{
    public Ballon ballon; // Référence au script Ballon
    public Slider scaleSlider; // Référence à la barre de défilement UI

    void Update(){
        UpdateSlider();
    }

    private void UpdateSlider(){
        if (ballon != null && scaleSlider != null){
            float scaleProgress = Mathf.Clamp01(ballon.ScaleTime / ballon.inflateTime);
            scaleSlider.value = scaleProgress;
            scaleSlider.gameObject.SetActive(scaleSlider.value > 0);
        }
    }
}

