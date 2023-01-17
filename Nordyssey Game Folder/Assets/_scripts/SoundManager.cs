using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> soundClips;
    private AudioSource audioSource;
    public AudioClip currentClip;

    public void PlaySound(string soundName)
    {
        Debug.Log("Sound name is " + soundName);
        for (int i = 0; i < soundClips.Count; i++)
        {
            Debug.Log("Clip name is " + soundClips[i].name);
            if (soundClips[i].name == soundName)
            {
                currentClip = soundClips[i];
                audioSource.clip = currentClip;
                audioSource.Play();
                return;
            }
        }
    }
}
