using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public GameObject Fire;//fire effect
    public Quaternion FireRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "DefectiveDuck") {
            Instantiate(Fire, transform.position, FireRotation);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "PerfectDuck") {
            Instantiate(Fire, transform.position, FireRotation);
            Destroy(other.gameObject);
        }
    }
}
