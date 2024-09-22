// Rougefort Luca B3JV1 Prog
// ButtonScript.cs
// GameJam rentr�e 2024-2025

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
            Debug.LogError("Le nom de la sc�ne n'est pas d�fini.");
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
        // Int�gration des sons
        // TODO: Ajouter le code pour jouer un son de changement de sc�ne
    }

    private void PlaySceneChangeVFX(){
        // Int�gration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de changement de sc�ne
    }

    private void PlayQuitGameSound(){
        // Int�gration des sons
        // TODO: Ajouter le code pour jouer un son de sortie du jeu
    }

    private void PlayQuitGameVFX(){
        // Int�gration des VFX
        // TODO: Ajouter le code pour jouer un effet visuel de sortie du jeu
    }
}



