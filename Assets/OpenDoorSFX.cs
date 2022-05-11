using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorSFX : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip openLockerClip;

    public void OpenDoorClip() {
        audioSource.PlayOneShot(openLockerClip);
    }
}
