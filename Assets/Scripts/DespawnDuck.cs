using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnDuck : MonoBehaviour {
    ValidationDuckManager validationDuckManager;
    [SerializeField] Countdown countdown;
    public float TimeLostPerDuck;
    private void Start() {
        TimeLostPerDuck = 20f;
        validationDuckManager = FindObjectOfType<ValidationDuckManager>();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "DefectiveDuck") {

            countdown.DecreaseTime(TimeLostPerDuck);

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "PerfectDuck") {

            validationDuckManager.IncreaseScorePoint();

            Destroy(collision.gameObject);
        }
    }

}
