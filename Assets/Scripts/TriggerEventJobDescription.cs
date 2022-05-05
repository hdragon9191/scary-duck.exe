using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventJobDescription : MonoBehaviour {
    [SerializeField] FirstPersonController firstPersonController;
    [SerializeField] Transform audioSpeakerPosition;
    [SerializeField] Animator animator;
    [SerializeField] GameObject cameraRoot;
    GameObject cameraRootStarter = null;
    bool triggerEventIsEnded;

    void Start() {
        cameraRootStarter = cameraRoot;
        animator.enabled = false;
        triggerEventIsEnded = false;
        firstPersonController.enabled = false;
        StartCoroutine(JobDescriptionTutorial());
    }

    IEnumerator JobDescriptionTutorial() {
        animator.enabled = true;
        yield return new WaitForSeconds(3f);

        triggerEventIsEnded = true;
        animator.enabled = false;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && triggerEventIsEnded) {
            firstPersonController.enabled = true;
            animator.Rebind();
        }
    }

}
