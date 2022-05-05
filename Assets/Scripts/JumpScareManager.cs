using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScareManager : MonoBehaviour
{
    public GameObject[] Jumpscares;
    public void JumpScare(float JumpScareIndex)
    {
        if (JumpScareIndex == 0)
        {
            Instantiate(Jumpscares[0], new Vector3(0, -100f, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
