using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltActivator : MonoBehaviour {
    public bool IsActive;
    int children;

    private void Start() {
        children = transform.childCount;
    }
    void Update() {
        OperativeMachine(IsActive);
    }

    private void OperativeMachine(bool active) {
        for (int i = 0; i < children; ++i)
            transform.GetChild(i).gameObject.SetActive(active);
    }
}

