using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolManager : MonoBehaviour
{
    public scaryDuckAI scaryDuckAI;
    public Transform[] PatrolCheckPoints;
    public int PatrolIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // PatrolCheckPoints[PatrolIndex].gameObject.SetActive(true);
        if (PatrolIndex >= PatrolCheckPoints.Length)
        {
            PatrolIndex = 0;
        }
        scaryDuckAI.PatrolCheckPoint = PatrolCheckPoints[PatrolIndex];
    }
    // void LateUpdate()
    // {
    //     PatrolCheckPoints[PatrolIndex].gameObject.SetActive(false);
    // }
}
