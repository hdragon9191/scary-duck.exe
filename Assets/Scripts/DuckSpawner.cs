using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    public float TimeToSpawnDuck = 5f;
    //this is so we can still have the original value of TimeToSpawnDuck even after changing it 
    private float _TimeToSpawnDuck;
	[Tooltip("Change this number to change the chance of a bad duck to spawn")]
    public float ChangeOfBadDuck = 10;
    public GameObject[] Ducks;
    // Start is called before the first frame update
    void Start()
    {
        _TimeToSpawnDuck = TimeToSpawnDuck;
    }

    // Update is called once per frame
    void Update()
    {
        TimeToSpawnDuck -= Time.deltaTime;
        if (TimeToSpawnDuck > 0) return; 
        float ChangeOfGoodDuckToSpawn = Random.Range(0, 101);
        if(ChangeOfGoodDuckToSpawn < (100/ChangeOfBadDuck))
        {
            SpawnDuck(1);
        }
        if(ChangeOfGoodDuckToSpawn >= (100/ChangeOfBadDuck))
        {
            SpawnDuck(0);
        }
    }
    void SpawnDuck(int DuckIndex)
    {
        //if DuckIndex is 0 then it will spawn a good duck if it is 1 it will spawn a bad duck
        if (DuckIndex == 0)
        {
            Instantiate(Ducks[0], transform.position , Quaternion.identity);
        }
        else if (DuckIndex == 1)
        {
            Instantiate(Ducks[1], transform.position , Quaternion.identity);
        }
        TimeToSpawnDuck = _TimeToSpawnDuck;
    }
}
