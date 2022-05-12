using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour {
	public float TimeStart = 1000;
	public TextMeshProUGUI textBox;

	void Start() {
		textBox.text = TimeStart.ToString();
	}

	void Update() {
		TimeStart -= Time.deltaTime;
		textBox.text = Mathf.Round(TimeStart).ToString();
	}

	public void DecreaseTime(float amount) {
		TimeStart -= amount;
	}

}