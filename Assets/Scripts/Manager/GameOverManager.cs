using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    [SerializeField] Countdown countdown;
    [SerializeField] ValidationDuckManager validationDuckManager;
    public float FinalScore;
    public static GameOverManager instance;
    SceneHandler sceneHandler;

    private void Awake() {
        FinalScore = 0;
        sceneHandler = FindObjectOfType<SceneHandler>();
    }

    void Update() {
        if (SceneManager.GetActiveScene().name == "Level 1") {
            if (countdown.TimeStart < 0) {
                sceneHandler.LoadGameOver();
            }
            else if (validationDuckManager.ScorePoint >= 1000) {
                FinalScore = countdown.TimeStart;
                sceneHandler.LoadGameWin(FinalScore);
            }
        }

    }

}
