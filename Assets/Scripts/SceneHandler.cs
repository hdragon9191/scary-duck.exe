using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneHandler : MonoBehaviour {
    public bool menuOnOff;
    public static SceneHandler instance;
    public float FinalScore;
    private void Start() {
        DontDestroyOnLoad(this);
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else
            Destroy(gameObject);
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }
    public void FirstLevel() {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadGameOver() {
        SceneManager.LoadScene("GameOver");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void LoadGameWin(float finalScore) {
        SceneManager.LoadScene("GameWin");
        FinalScore = finalScore;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void NewLevel() {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame() {
        Application.Quit();
    }
    
}
