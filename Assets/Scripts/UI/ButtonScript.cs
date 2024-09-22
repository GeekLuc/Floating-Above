// Rougefort Luca B3JV1 Prog
// ButtonScript.cs
// GameJam rentrée 2024-2025

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour{
    public void ChangeSceneOrQuit(string sceneName){
        if (string.IsNullOrEmpty(sceneName)){
            QuitGame();
        }else{
            ChangeScene(sceneName);
        }
    }

    private void ChangeScene(string sceneName){
        if (!string.IsNullOrEmpty(sceneName)){
            SceneManager.LoadScene(sceneName);
            PlaySceneChangeSound();
            PlaySceneChangeVFX();
        }else{
            Debug.LogError("Le nom de la scène n'est pas défini.");
        }
    }

    private void QuitGame(){
        Debug.Log("Quitter le jeu.");
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
        PlayQuitGameSound();
        PlayQuitGameVFX();
    }

    private void PlaySceneChangeSound(){
        // Intégration des sons
        // TODO: Ajouter le code pour jouer un son de changement de scène
    }

    private void PlaySceneChangeVFX(){
        // Intégration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de changement de scène
    }

    private void PlayQuitGameSound(){
        // Intégration des sons
        // TODO: Ajouter le code pour jouer un son de sortie du jeu
    }

    private void PlayQuitGameVFX(){
        // Intégration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de sortie du jeu
    }
}



