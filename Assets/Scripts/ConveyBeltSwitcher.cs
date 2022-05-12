using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyBeltSwitcher : MonoBehaviour {
    [SerializeField] ConveyorBeltActivator conveyorBeltActivator;

    void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            conveyorBeltActivator.IsActive = !conveyorBeltActivator.IsActive;
            //TODO add noise of switch off
        }
    }
}
