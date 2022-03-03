using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public AudioClip deathSFX;

    public AudioClip goombaSFX;

    public AudioClip coinSFX;

    public AudioClip levelSFX;

    private AudioSource audio_source;

    void Awake()
    {

        audio_source = GetComponent<AudioSource>();

    }   

    public void DeathSound()
    {
        
        audio_source.PlayOneShot(deathSFX);

    }

    public void GoombaSound()
    {


        audio_source.PlayOneShot(goombaSFX);

    }

    public void CoinSound()
    {


        audio_source.PlayOneShot(coinSFX);

    }

    public void levelSound()
    {


        audio_source.PlayOneShot(levelSFX);

    }
}
