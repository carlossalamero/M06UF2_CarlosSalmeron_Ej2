using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCMManager : MonoBehaviour
{

    private AudioSource audio_source;

    void Awake ()
    {

        audio_source = GetComponent<AudioSource>();

    }

    // Start is called before the first frame update
    void Start()
    {
        //Reproducimos la BGM
        audio_source.Play(); 

    }

    public void STOPBGM()
    {

        audio_source.Stop();

    }

   
}
