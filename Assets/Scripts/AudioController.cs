using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip loseSound;

    [SerializeField]
    private AudioClip deathSound;

    [SerializeField]
    private AudioClip fearVoiceSound;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayLoseSound()
    {
        audioSource.clip = loseSound;
        audioSource.Play();
    }

    public void PlayDeathSound()
    {
        audioSource.clip = deathSound;
        audioSource.Play();
    }

    public void PlayFearVoiceSound()
    {
        audioSource.clip = fearVoiceSound;
        audioSource.Play();
    }
}
