using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMicsher : MonoBehaviour
{
    public AudioClip loseSound;
    [SerializeField] private AudioClip BattleMusic;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Lose()
    {
        audioSource.clip = loseSound;
        audioSource.Play();
    }
}
