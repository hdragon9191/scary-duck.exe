using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scaryDuckAI : MonoBehaviour
{
    [SerializeField]
    private Transform goal;
    public GameObject Player;
    public JumpScareManager BooScaryManager;
    // Start is called before the first frame update
    void Update()
    {
        var scarDuckAgent = GetComponent<NavMeshAgent>();
        scarDuckAgent.destination = goal.position;
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            KillPlayer(0);
        }
    }
    //call this void when the player wishes to die
    //Jump scare index goes like this 0 for Bad duck jumpscare, 1 for(when second jump scare is to be added)
    void KillPlayer(float JumpScareIndex)
    {
        BooScaryManager.JumpScare(JumpScareIndex);
        Destroy(gameObject);
        Debug.Log("KilledPlayer");
    }
}
