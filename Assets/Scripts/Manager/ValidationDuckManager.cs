using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValidationDuckManager : MonoBehaviour {

    public int ScorePoint;
    private int defectiveDuckCounter;
    [SerializeField] TextMeshProUGUI defectiveDuckCounterText;
    [SerializeField] TextMeshProUGUI scorePointText;

    void Start() {
        ScorePoint = 0;
        defectiveDuckCounter = 0;
        scorePointText.text = "Duck delivered: " + ScorePoint;
        defectiveDuckCounterText.text = "Duck missed " + defectiveDuckCounter;
    }

    public void IncreaseScorePoint() {
        ScorePoint++;
        scorePointText.text = "Duck delivered: " + ScorePoint;
    }

    public void IncreaseDefectiveDuckCounter() {
        defectiveDuckCounter++;
        defectiveDuckCounterText.text = "Duck missed " + defectiveDuckCounter;
    }
}
