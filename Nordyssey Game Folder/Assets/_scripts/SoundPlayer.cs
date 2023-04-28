using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public string soundName;

    private void PlaySound()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound(soundName);
    }

    private void PlayNordyssey()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("NordysseyPokemon");
    }
}
