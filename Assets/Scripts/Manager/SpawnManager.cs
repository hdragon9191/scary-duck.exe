using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SpawnManager : MonoBehaviour {
    public float AmountTimeSpawn;
    int children;
    [SerializeField] GameObject tooltipText;
    [SerializeField] GameObject spawnRatio;
    public float MaxValueSpawn;
    public float MinValueSpawn;

    private void Start() {
        MaxValueSpawn = 2f;
        MinValueSpawn = 0.3f;
        AmountTimeSpawn = 1f;
        children = transform.childCount;
    }

    private void Update() {
        spawnRatio.GetComponent<TextMeshPro>().text = "" + Math.Round(AmountTimeSpawn, 2); //dump
    }

    private void OnTriggerStay(Collider other) {
        if (Input.GetKeyDown(KeyCode.DownArrow) && other.tag == "Player") {
            AmountTimeSpawn = (AmountTimeSpawn - 0.1f);
            if (AmountTimeSpawn <= MinValueSpawn) {
                AmountTimeSpawn = MinValueSpawn;
            }
            CalibrateRatioSpawn(AmountTimeSpawn);
            //TODO add noise of switch off
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && other.tag == "Player") {
            AmountTimeSpawn = (AmountTimeSpawn + 0.1f);
            if (AmountTimeSpawn >= MaxValueSpawn) {
                AmountTimeSpawn = MaxValueSpawn;
            }
            CalibrateRatioSpawn(AmountTimeSpawn);
            //TODO add noise of switch off
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            tooltipText.SetActive(true);
            tooltipText.GetComponent<TextMeshProUGUI>().text = "Press Arrow Down or Up to variate the spawn ratio";
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
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

