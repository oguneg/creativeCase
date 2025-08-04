using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip spawnClip, combatClip, tubeClip;
    public void PlaySpawn()
    {
        audioSource.PlayOneShot(spawnClip);
    }

    public void PlayCombat()
    {
        audioSource.PlayOneShot(combatClip);
    }

    public void PlayTube()
    {
        audioSource.PlayOneShot(tubeClip);
    }
}
