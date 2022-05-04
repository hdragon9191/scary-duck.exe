using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ValidationDuckManager : MonoBehaviour {

    private int scorePoint;
    private int defectiveDuckCounter;
    [SerializeField] TextMeshProUGUI defectiveDuckCounterText;
    [SerializeField] TextMeshProUGUI scorePointText;

    void Start() {
        scorePoint = 0;
        defectiveDuckCounter = 0;
    }

    public void IncreaseScorePoint() {
        scorePoint++;
        scorePointText.text = "Duck delivered: " + scorePoint;
    }

    public void IncreaseDefectiveDuckCounter() {
        defectiveDuckCounter++;
        defectiveDuckCounterText.text = "Duck missed " + defectiveDuckCounter;
    }
}
