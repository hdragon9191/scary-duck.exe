using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScorePoint : MonoBehaviour
{
    SceneHandler sceneHandler;
    [SerializeField] TextMeshProUGUI finalScorePointText;
    void Start()
    {
        sceneHandler = FindObjectOfType<SceneHandler>();
    }

    void Update()
    {
        finalScorePointText.text = "You Won! Total score is: " + Mathf.RoundToInt(sceneHandler.FinalScore);
    }
}
