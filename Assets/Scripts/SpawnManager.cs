using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour {
    public float AmountTimeSpawn;
    int children;
    [SerializeField] GameObject tooltipText;

    private void Start() {
        AmountTimeSpawn = 1f;
        children = transform.childCount;
    }

    private void OnTriggerStay(Collider other) {
        //TODO manage a cap for min and max
        if (Input.GetKeyDown(KeyCode.DownArrow) && other.tag == "Player") {
            AmountTimeSpawn = (AmountTimeSpawn - 0.1f);
            CalibrateRatioSpawn(AmountTimeSpawn);
            //TODO add noise of switch off
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && other.tag == "Player") {
            AmountTimeSpawn = (AmountTimeSpawn + 0.1f);
            CalibrateRatioSpawn(AmountTimeSpawn);
            //TODO add noise of switch off
        }
    }

    private void OnTriggerEnter(Collider other) {
        tooltipText.SetActive(true);
        tooltipText.GetComponent<TextMeshProUGUI>().text = "Press Arrow Down or Up to variate the spawn ratio";
    }
    private void OnTriggerExit(Collider other) {
        tooltipText.SetActive(false);
    }

    private void CalibrateRatioSpawn(float amount) {
        for (int i = 0; i < children; ++i) {
            transform.GetChild(i).gameObject.TryGetComponent<DuckSpawner>(out DuckSpawner duckSpawner);
            if (duckSpawner != null)
                duckSpawner.TuningSpawnDuck = amount;
        }

    }
}

