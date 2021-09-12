using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject audioSourceStore;
    private AudioSource[] audioSources;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Get one of the audio sources in the game object
        audioSources = audioSourceStore.GetComponents<AudioSource>();
        System.Random random = new System.Random();
        int index = random.Next(audioSources.Length);
        AudioSource audioSource = audioSources[index];

        // Play it
        audioSource.Play();
    }
}
