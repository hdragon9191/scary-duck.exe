using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScorePoint : MonoBehaviour
{
    GameOverManager gameOverManager;
    [SerializeField] TextMeshProUGUI finalScorePointText;
    void Start()
    {
        gameOverManager = FindObjectOfType<GameOverManager>();
    }

    void Update()
    {
        finalScorePointText.text = "You Won! Total score is: " + Mathf.RoundToInt(gameOverManager.FinalScore);
    }
}
