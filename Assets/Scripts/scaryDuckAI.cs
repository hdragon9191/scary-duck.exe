using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scaryDuckAI : MonoBehaviour
{
    [SerializeField]
    private Transform goal;
    // Start is called before the first frame update
    void Update()
    {
        var scarDuckAgent = GetComponent<NavMeshAgent>();
        scarDuckAgent.destination = goal.position;
    }

}
