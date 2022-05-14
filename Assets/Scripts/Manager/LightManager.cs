using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightManager : MonoBehaviour {
    public bool IsActive;
    int children;
    [SerializeField] GameObject tooltipText;
    [SerializeField] Countdown countdown;

    private void Start() {
        IsActive = true;
        children = transform.childCount;
    }
    void Update() {
        if (countdown.TimeStart == 400f) {
            IsActive = false;
        }
        if (countdown.TimeStart == 700f) {
            IsActive = false;
        }
        if (countdown.TimeStart == 100f) {
            IsActive = false;
        }
        LightsActive(IsActive);
    }

    private void LightsActive(bool active) {
        for (int i = 0; i < children; ++i)
            transform.GetChild(i).gameObject.SetActive(active);
    }


    private void OnTriggerStay(Collider other) {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.tag == "Player") {
            IsActive = !IsActive;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            tooltipText.SetActive(true);
            tooltipText.GetComponent<TextMeshProUGUI>().text = "Press E to reset the lights";
        }

    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
            tooltipText.SetActive(false);
    }


}
