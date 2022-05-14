using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorAudioController : MonoBehaviour
{
    public ConveyorBeltActivator activator;
    public AudioSource[] audioSources;
    public AudioClip startClip;
    public AudioClip loopClip;
    public AudioClip stopClip;

    private bool is_starting = false;
    private bool prev_is_active = false;

    void Update()
    {
        bool is_active = activator.IsActive;

        if (is_active && !prev_is_active)
        {
            foreach(AudioSource source in audioSources)
            {
                source.Stop();
                source.loop = false;
                source.clip = startClip;
                source.PlayDelayed(Random.Range(0.0f, 0.1f));
            }
            is_starting = true;
        }
        else if ((!is_active) && prev_is_active)
        {
            foreach (AudioSource source in audioSources)
            {
                source.Stop();
                source.loop = false;
                source.PlayOneShot(stopClip);
            }
            is_starting = false;
        }

        if (is_starting)
        {
            if((!audioSources[0].isPlaying) && prev_is_active)
            {
                foreach (AudioSource source in audioSources)
                {
                    source.Stop();
                    source.loop = true;
                    source.clip = loopClip;
                    source.Play();
                }
                is_starting = false;
            }
        }

        prev_is_active = is_active;
    }
}
