using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip[] pulando;
    public AudioClip[] morrendo;
    public AudioClip trocandoGravidade;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    

    void Update()
    {
        
    }

    public void PlayJumpSound()
    {
        audioSource.volume = 0.8f;
        audioSource.PlayOneShot(pulando[Random.Range(0, pulando.Length)]);
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(trocandoGravidade);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(morrendo[Random.Range(0, morrendo.Length)]);
    }
}
