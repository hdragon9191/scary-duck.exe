using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scaryDuckAI : MonoBehaviour
{
    [SerializeField]
    private Transform EyePosition; //eyeposition is where the raycast will be shot
    public Transform Player;
    public JumpScareManager BooScaryManager;
    [Tooltip("how far can the duck see")]
    public float SightDistance;
    private Vector3 fwd;
    public LayerMask PlayerLayer;
    public NavMeshAgent scaryDuckAgent;
    public Transform PatrolCheckPoint;

    // Start is called before the first frame update
    void Update()
    {
        // if ()
        {
        Patrol();
        }
        // else
        {
            // FollowPlayer();
        }
    }
    void Patrol()
    {
        Debug.Log("Patrolling");
        scaryDuckAgent.destination = PatrolCheckPoint.position;
    }
    void FollowPlayer()
    {
        //fwd = forward
        fwd = transform.TransformDirection (Vector3.forward);
        RaycastHit hit; 
        if (Physics.Raycast(EyePosition.position, fwd, out hit, SightDistance, PlayerLayer)) 
        {
            Player = hit.transform;
            scaryDuckAgent.destination = Player.position;
            Debug.DrawRay(EyePosition.position, fwd * 1000, Color.green, PlayerLayer);
        }
        else
        {
            Debug.DrawRay(EyePosition.position, fwd * 1000, Color.red, PlayerLayer);
        }

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
