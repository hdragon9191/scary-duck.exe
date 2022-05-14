using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValidationDuckManager : MonoBehaviour {

    public int ScorePoint;
    [SerializeField] TextMeshProUGUI scorePointText;

    void Start() {
        ScorePoint = 0;
        scorePointText.text = "Duck delivered: " + ScorePoint;
    }

    public void IncreaseScorePoint() {
        ScorePoint++;
        scorePointText.text = "Duck delivered: " + ScorePoint;
    }

}
