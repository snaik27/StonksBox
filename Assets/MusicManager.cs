using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip roundMusic, loopMusic;

    public void PlayLoopMusic()
    {
        GetComponent<AudioSource>().clip = loopMusic;
        GetComponent<AudioSource>().Play();
    }

    public void PlayRoundMusic()
    {
        GetComponent<AudioSource>().clip = roundMusic;
        GetComponent<AudioSource>().Play();
    }
}
