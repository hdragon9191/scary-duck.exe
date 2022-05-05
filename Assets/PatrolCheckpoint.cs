using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolCheckpoint : MonoBehaviour
{
    public PatrolManager PatrolManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "ScaryDuck") {
            PatrolManager.PatrolIndex++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
