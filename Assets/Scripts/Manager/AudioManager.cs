using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip openLockerClip;
    [SerializeField] AudioClip buttonClip;
    [SerializeField] AudioClip conveyorOn;
    [SerializeField] AudioClip conveyorOff;

    void Awake() {
        int numGameSessions = FindObjectsOfType<AudioManager>().Length;
        if (numGameSessions > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OpenDoorClip() {
        audioSource.PlayOneShot(openLockerClip);
    }

    public void ButtonClip() {
        audioSource.PlayOneShot(buttonClip);
    }

    public void ConveyorOnClip() {
        audioSource.PlayOneShot(conveyorOn);
    }
    public void ConveyorOffClip() {
        audioSource.PlayOneShot(conveyorOff);
    }

}
