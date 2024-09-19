using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    GameJam 2024-2025 - Team 3
    ButtonScript.cs
    Rougefort Luca B3JV1
*/

public class ButtonScript : MonoBehaviour{

    public void ChangeSceneOrQuit(string sceneName){
        if (sceneName==""){
            QuitGame();
        }else{
            ChangeScene(sceneName);
        }
    }

    private void ChangeScene(string sceneName){
        if (!string.IsNullOrEmpty(sceneName)){
            SceneManager.LoadScene(sceneName);
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
    }
}

