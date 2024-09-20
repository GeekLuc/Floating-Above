using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Ajoutez cette ligne

/*
    GameJam 2024-2025 - Team 3
    SliderScript.cs
    Rougefort Luca B3JV1
*/

public class LifeBar : MonoBehaviour{
    public GameObject[] hearts;
    private int currentLife;

    void Start(){
        currentLife = hearts.Length - 1;
        for (int i = 0; i < hearts.Length; i++){
            hearts[i].SetActive(false);
        }
        if (hearts.Length > 0){
            hearts[currentLife].SetActive(true);
        }
    }

    public void Damage(){
        if (currentLife >= 0){
            Debug.Log("Dommage");
            hearts[currentLife].SetActive(false);
            currentLife--;
            if (currentLife >= 0){
                hearts[currentLife].SetActive(true);
            }else{
                Death();
            }
        }
    }

    public void Death(){
        Debug.Log("MORT");
        SceneManager.LoadScene("DeathScene");
    }
}
