using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConveyBeltSwitcher : MonoBehaviour {
    [SerializeField] ConveyorBeltActivator conveyorBeltActivator;
    [SerializeField] GameObject tooltipText;
    AudioManager audioManager;
    private void Start() {
        audioManager = FindObjectOfType<AudioManager>();
    }


    private void OnTriggerStay(Collider other) {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.tag == "Player") {
            conveyorBeltActivator.IsActive = !conveyorBeltActivator.IsActive;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            tooltipText.SetActive(true);
            tooltipText.GetComponent<TextMeshProUGUI>().text = "Press E to power On/Off";
        }

    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
            tooltipText.SetActive(false);
    }

}
