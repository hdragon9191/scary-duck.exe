using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneHandler : MonoBehaviour {
    public bool menuOnOff;
    //void Awake() {
    //    int numGameSessions = FindObjectsOfType<SceneHandler>().Length;
    //    if (numGameSessions > 1) {
    //        Destroy(gameObject);
    //    }
    //    else {
    //        DontDestroyOnLoad(gameObject);
    //    }
    //}

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
    public void FirstLevel() {
        SceneManager.LoadScene("Level 1");
    }

    public void RestartLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void QuitGame() {
        Application.Quit();
    }
    
}
