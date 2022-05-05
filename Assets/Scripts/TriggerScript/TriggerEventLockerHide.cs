using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventLockerHide : MonoBehaviour
{


    private void OnTriggerEnter(Collider other) {
        if (Input.GetKeyDown(KeyCode.F) && other.tag == "Player")
            gameObject.transform.GetChild(1).GetComponent<Animator>().enabled = true;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
