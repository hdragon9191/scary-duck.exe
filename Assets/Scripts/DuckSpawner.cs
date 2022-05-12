using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour {

    [SerializeField] ConveyorBeltActivator conveyorBeltActivator;
    public float TimeToSpawnDuck = 2f;
    //this is so we can still have the original value of TimeToSpawnDuck even after changing it 
    private float _TimeToSpawnDuck;
    [Tooltip("Change this number to change the chance of a bad duck to spawn")]
    public float ChanceOfBadDuck = 10;
    public GameObject[] Ducks;
    // Start is called before the first frame update
    FactoryElectricity factoryElectricity;
    void Start() {
        _TimeToSpawnDuck = TimeToSpawnDuck;
        factoryElectricity = FindObjectOfType<FactoryElectricity>();
    }

    // Update is called once per frame
    void Update() {
        if (DeactiveSpawn() && factoryElectricity.IsPowered) {
            TimeToSpawnDuck -= Time.deltaTime;
            if (TimeToSpawnDuck > 0) return;
            float ChangeOfGoodDuckToSpawn = Random.Range(0, 101);
            if (ChangeOfGoodDuckToSpawn < (100 / ChanceOfBadDuck)) {
                SpawnDuck(1);
            }
            if (ChangeOfGoodDuckToSpawn >= (100 / ChanceOfBadDuck)) {
                SpawnDuck(0);
            }
        }
    }

    private bool DeactiveSpawn() {
        return conveyorBeltActivator.IsActive;
    }

    void SpawnDuck(int DuckIndex) {
        //if DuckIndex is 0 then it will spawn a good duck if it is 1 it will spawn a bad duck
        if (DuckIndex == 0) {
            GameObject duck = Instantiate(Ducks[0], transform.position, Quaternion.identity);
            duck.transform.parent = this.transform;
        }
        else if (DuckIndex == 1) {
            GameObject duck = Instantiate(Ducks[1], transform.position, Quaternion.identity);
            duck.transform.parent = this.transform;
        }
        TimeToSpawnDuck = _TimeToSpawnDuck;
    }
}
