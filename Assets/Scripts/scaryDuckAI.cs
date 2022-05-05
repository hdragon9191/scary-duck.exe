using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scaryDuckAI : MonoBehaviour
{
    [SerializeField]
    private Transform EyePosition; //eyeposition is where the raycast will be shot
    public Transform Target;
    public JumpScareManager BooScaryManager;
    [Tooltip("how far can the duck see")]
    public float SightDistance;
    private Vector3 fwd;
    public LayerMask PlayerLayer;
    public NavMeshAgent scaryDuckAgent;
    public Transform PatrolCheckPoint;
    public bool TargetFound;
    public int AIMode;//this number is just so we can know what mode the AI is in changes this will NOT change the AI mode, 0 is for patrolling, 1 is for follow, 2 is for search
    Coroutine SearchCoroutine;

    // Start is called before the first frame update
    void Update()
    {
        if (!TargetFound)
        {
            Patrol();
        }
        Look();
    }
    void Patrol()
    {
        AIMode = 0;
        Debug.Log("Patrolling");
        scaryDuckAgent.destination = PatrolCheckPoint.position;
    }
    void Look()
    {
        //fwd = forward
        fwd = transform.TransformDirection (Vector3.forward);
        RaycastHit hit; 
        if (Physics.Raycast(EyePosition.position, fwd, out hit, SightDistance, PlayerLayer)) 
        {
            Target = hit.transform;
            FollowPlayer();
            Debug.DrawRay(EyePosition.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            TargetFound = true;
        }
        else
        {
            Debug.DrawRay(EyePosition.position, transform.TransformDirection(Vector3.forward) * 50, Color.red);
            if (TargetFound)
            {
                SearchCoroutine = StartCoroutine(Search());
            }
            TargetFound = false;
        }
    }


    IEnumerator Search()
    
    {
       float duration = Time.time + 3.0f;
       while (Time.time<duration)
       {
            AIMode = 2;
            Debug.Log("search");
            transform.LookAt(Target);
            scaryDuckAgent.destination = Target.position;
            yield return null;
       }
    }
    void FollowPlayer()
    {
        AIMode = 1;
        scaryDuckAgent.destination = Target.position;
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
