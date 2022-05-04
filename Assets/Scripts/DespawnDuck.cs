using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnDuck : MonoBehaviour {
    ValidationDuckManager validationDuckManager;
    private void Start() {
        validationDuckManager = FindObjectOfType<ValidationDuckManager>();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "DefectiveDuck") {

            validationDuckManager.IncreaseDefectiveDuckCounter();

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "PerfectDuck") {

            validationDuckManager.IncreaseScorePoint();

            Destroy(collision.gameObject);
        }
    }

}
