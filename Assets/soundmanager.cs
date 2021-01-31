using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanager : MonoBehaviour
{
    public AudioClip button, tinnyButton;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        audioSource.clip = button;
        audioSource.Play();
    }

    public void PlayTinnyButtonSound()
    {
        audioSource.clip = tinnyButton;
        audioSource.Play();
    }
}
