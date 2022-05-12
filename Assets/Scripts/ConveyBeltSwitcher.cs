using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConveyBeltSwitcher : MonoBehaviour {
    [SerializeField] ConveyorBeltActivator conveyorBeltActivator;
    [SerializeField] GameObject tooltipText;
    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            conveyorBeltActivator.IsActive = !conveyorBeltActivator.IsActive;
            //TODO add noise of switch off
        }
    }

    private void OnTriggerEnter(Collider other) {
        tooltipText.SetActive(true);
        tooltipText.GetComponent<TextMeshProUGUI>().text = "Press E to power On/Off";
    }
    private void OnTriggerExit(Collider other) {
        tooltipText.SetActive(false);
    }

}
