// Rougefort Luca B3JV1 Prog
// LifeBar.cs
// GameJam rentrée 2024-2025

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeBar : MonoBehaviour{
    public GameObject[] hearts;
    private int currentLife;

    void Start(){
        InitializeHearts();
    }

    private void InitializeHearts(){
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
            ApplyDamage();
            PlayDamageSound();
            PlayDamageVFX();
            if (currentLife < 1){
                Death();
            }
        }
    }

    private void ApplyDamage(){
        Debug.Log("Dommage");
        hearts[currentLife].SetActive(false);
        currentLife--;
        if (currentLife >= 1){
            hearts[currentLife].SetActive(true);
        }
    }

    public void Death(){
        Debug.Log("MORT");
        SceneManager.LoadScene("DeathScene");
    }


    public bool HasLivesLeft(){
        return currentLife >= 1;
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


