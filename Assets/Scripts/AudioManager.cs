using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
