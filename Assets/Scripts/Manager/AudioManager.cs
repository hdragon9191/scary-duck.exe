using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [SerializeField] AudioSource backgroundAudioSource;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioSource fxAudioSource;
    [SerializeField] AudioSource paAudioSource;
    [SerializeField] AudioClip lightsSwitchOn;
    [SerializeField] AudioClip lightsSwitchOff;
    [SerializeField] AudioClip ambienceLightsOn;
    [SerializeField] AudioClip ambienceLightsOff;
    [SerializeField] AudioClip music;
    [SerializeField] AudioClip openLockerClip;
    [SerializeField] AudioClip buttonClip;
    [SerializeField] AudioClip conveyorOn;
    [SerializeField] AudioClip conveyorOff;
    [SerializeField] AudioClip[] paClips;

    private bool music_on = false;
    private float fade = 0.0f;
    private float fadeTime = 8.0f;
    private float backgroundVolume;
    private float musicVolume;

    private float pa_wait_time = 15.0f;
    private float pa_timer = 0.0f;
    private int pa_count = 0;
    private bool pa_done = false;

    void Awake() {
        int numGameSessions = FindObjectsOfType<AudioManager>().Length;
        if (numGameSessions > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }

        backgroundVolume = backgroundAudioSource.volume;
        musicVolume = musicAudioSource.volume;

        //StartMusic();
        //paAudioSource.PlayOneShot(paClips[0]);
    }

    private void FixedUpdate()
    {
        Fade();
        if (!pa_done) CheckPA();
    }

    private void Fade()
    {
        if (music_on && (fade < 1.0f))
        {
            fade += (Time.fixedDeltaTime / fadeTime);
            if (fade > 1.0f) fade = 1.0f;
            musicAudioSource.volume = fade * musicVolume;
            backgroundAudioSource.volume = (1.0f - fade) * backgroundVolume;
        }
        else if (!music_on && (fade > 0.0f))
        {
            fade -= (Time.fixedDeltaTime / fadeTime);
            if (fade < 0.0f) fade = 0.0f;
            musicAudioSource.volume = (1.0f - fade) * musicVolume;
            backgroundAudioSource.volume = fade * backgroundVolume;
        }
    }

    private void CheckPA()
    {
        pa_timer += Time.fixedDeltaTime;

        if (pa_timer >= pa_wait_time)
        {
            if (pa_count < paClips.Length)
            {
                paAudioSource.PlayOneShot(paClips[pa_count]);
                pa_count++;
            }
            else
            {
                StartMusic();
                pa_done = true;
            }
            pa_timer = 0.0f;
        }
    }

    public void LightsOn()
    {
        backgroundAudioSource.clip = ambienceLightsOn;
        backgroundAudioSource.Play();
    }

    public void LightsOff()
    {
        backgroundAudioSource.clip = ambienceLightsOff;
        backgroundAudioSource.Play();
    }

    public void StartMusic()
    {
        music_on = true;
        musicAudioSource.Stop();
        musicAudioSource.Play();
    }

    public void StopMusic()
    {
        music_on = false;
    }

    public void OpenDoorClip() {
        fxAudioSource.PlayOneShot(openLockerClip);
    }

    public void ButtonClip() {
        fxAudioSource.PlayOneShot(buttonClip);
    }

    public void ConveyorOnClip() {
        fxAudioSource.PlayOneShot(conveyorOn);
    }
    public void ConveyorOffClip() {
        fxAudioSource.PlayOneShot(conveyorOff);
    }

}
