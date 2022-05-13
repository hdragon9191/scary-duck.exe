using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {
    [SerializeField] Countdown countdown;
    [SerializeField] ValidationDuckManager validationDuckManager;
    public float FinalScore;
    public static GameOverManager instance;

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

    void Update() {
        if (SceneManager.GetActiveScene().name == "Level 1") {
            if (countdown.TimeStart < 0) {
                SceneManager.LoadScene("GameOver");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else if (validationDuckManager.ScorePoint >= 1000) {
                FinalScore = countdown.TimeStart;
                SceneManager.LoadScene("GameWin");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

    }
}
