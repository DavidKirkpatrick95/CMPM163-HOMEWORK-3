using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

//to call sound in other scripts say,
//FindObjectOfType<AudioManager>().Play("Sound name here");


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;



    // Start is called before the first frame update
    void Awake()
    {

        foreach(Sound x in sounds)
        {

            x.source = gameObject.AddComponent<AudioSource>();
            x.source.clip = x.clip;
            x.source.volume = x.volume;
            x.source.pitch = x.pitch;
            x.source.loop = x.loop;
        }
        
    }

public void Play(string name)
    {
        Sound x = Array.Find(sounds, sound => sound.name == name);
        if (x == null)
            return;
        x.source.Play();


    }
}
