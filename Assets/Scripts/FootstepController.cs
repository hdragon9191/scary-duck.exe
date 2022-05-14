using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public AudioManager audioManager;

    private FirstPersonController firstPersonController;
    private float timer = 0.0f;
    private float time_factor = 0.4f;
    private bool is_left = false;

    void Start()
    {
        firstPersonController = GetComponent<FirstPersonController>();
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime * time_factor * firstPersonController._speed;

        if(timer > 1.0f)
        {
            if(is_left) audioManager.FootstepLeft();
            else audioManager.FootstepRight();

            is_left = !is_left;
            timer = 0.0f;
        }
    }
}
