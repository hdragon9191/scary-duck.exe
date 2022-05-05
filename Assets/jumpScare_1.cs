using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScare_1 : MonoBehaviour
{
    public GameObject allTheLights;
    private Transform JumpScareLookTarget;
    // Start is called before the first frame update
    void Start()
    {
        JumpScareLookTarget = GameObject.FindGameObjectWithTag("JumpScareLookTarget").transform;
        allTheLights = GameObject.FindGameObjectWithTag("AllTheLights");
        allTheLights.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // JumpScareTarget is the place the jump scare should go to be in front of the player
        Transform JumpScareTarget = GameObject.FindGameObjectWithTag("JumpScareTarget").transform;
        transform.LookAt(JumpScareLookTarget);
        transform.position = JumpScareTarget.position;
    }
}
