using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour {
	public float timeStart = 1000;
	public TextMeshProUGUI textBox;

	void Start() {
		textBox.text = timeStart.ToString();
	}

	void Update() {
		timeStart -= Time.deltaTime;
		textBox.text = Mathf.Round(timeStart).ToString();
        if (timeStart <= 0) {
			Debug.Log("GameOver");
			//TODO Gameover overlay or something similar
        }
	}
}