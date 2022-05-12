using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] Countdown countdown;
    [SerializeField] ValidationDuckManager validationDuckManager;
 
    void Update()
    {
        if (countdown.TimeStart < 0) {
            SceneManager.LoadScene("GameOver");
        }
        if (validationDuckManager.ScorePoint>=1000) {
            SceneManager.LoadScene("GameWin");
        }
    }
}
