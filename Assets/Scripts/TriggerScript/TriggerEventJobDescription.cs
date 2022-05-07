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
    [SerializeField] GameObject duckImageToShow;
    [SerializeField] AudioClip jobDescriptionVocal;
    [SerializeField] AudioSource audioSource;
    [SerializeField] DuckSpawner DuckSpawner;

    GameObject cameraRootStarter = null;
    bool triggerEventIsEnded;
    public bool skipTutorial;
    void Start() {
        cameraRootStarter = cameraRoot;
        animator.enabled = false;
        triggerEventIsEnded = false;
        firstPersonController.enabled = false;
        DuckSpawner.enabled = false;
        if (!skipTutorial)
            StartCoroutine(JobDescriptionTutorial());
        else {
            firstPersonController.enabled = true;
        }
    }

    IEnumerator JobDescriptionTutorial() {
        animator.enabled = true;
        audioSource.PlayOneShot(jobDescriptionVocal);
        yield return new WaitForSeconds(3f);
        duckImageToShow.SetActive(true);
        triggerEventIsEnded = true;
        animator.enabled = false;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E) && triggerEventIsEnded) {
            duckImageToShow.SetActive(false);
            firstPersonController.enabled = true;
            DuckSpawner.enabled = true;
            animator.Rebind();
        }
    }

}
