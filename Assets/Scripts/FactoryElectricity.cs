using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryElectricity : MonoBehaviour {
    public bool IsPowered;
    int children;

    private void Start() {
        children = transform.childCount;
    }
    void Update() {
        OperativeMachine(IsPowered);
    }

    private void OperativeMachine(bool power) {
        for (int i = 0; i < children; ++i)
            transform.GetChild(i).gameObject.SetActive(power);
    }
}
