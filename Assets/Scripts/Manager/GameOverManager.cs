using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    [SerializeField] Countdown countdown;
    [SerializeField] ValidationDuckManager validationDuckManager;
    public float FinalScore;
    void Awake() {
        int numGameSessions = FindObjectsOfType<GameOverManager>().Length;
        if (numGameSessions > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update() {
        if (SceneManager.GetActiveScene().name == "Level 1") {
            if (countdown.TimeStart < 0) {
                SceneManager.LoadScene("GameOver");
            }
            else if (validationDuckManager.ScorePoint >= 1000) {
                FinalScore = countdown.TimeStart;
                SceneManager.LoadScene("GameWin");
            }
        }

    }
}
