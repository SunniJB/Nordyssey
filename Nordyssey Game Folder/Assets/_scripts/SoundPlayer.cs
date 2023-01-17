using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public string soundName;

    private void Start()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound(soundName);
    }
}
