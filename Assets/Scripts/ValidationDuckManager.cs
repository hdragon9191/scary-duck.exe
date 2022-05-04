using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidationDuckManager : MonoBehaviour {

    private int scorePoint;
    private int defectiveDuckCounter;

    void Start() {
        scorePoint = 0;
        defectiveDuckCounter = 0;
    }

    // Update is called once per frame
    void Update() {

    }

    public void IncreaseScorePoint() {
        scorePoint++;
    }

    public void IncreaseDefectiveDuckCounter() {
        defectiveDuckCounter++;
    }
}
