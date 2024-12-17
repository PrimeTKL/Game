using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("__________Audio Source_______")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("__________Audio Clip_________")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip takeDamge;
    public AudioClip gameOver;
    public AudioClip victory;
    public AudioClip attack;

    private void Start()
    {
         musicSource.clip = background;
         musicSource.Play();
    }
     public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
