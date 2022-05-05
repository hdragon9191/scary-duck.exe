using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    AudioSource gameBackground;
    Slider slider;
    public AudioMixer masterMixer;

    void Start() {
        slider = GetComponent<Slider>();
        gameBackground = FindObjectOfType<AudioSource>();
        slider.value = gameBackground.volume;

    }

    void Update() {
        gameBackground.volume = slider.value;
        SetSound((81* gameBackground.volume)-81);
    }

    public void SetSound(float soundLevel)
    {
        
        masterMixer.SetFloat("MasterVolume", soundLevel);
    }
}
