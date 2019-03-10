using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip Background;
    public AudioClip Win;
    public AudioSource musicSource;

    void Start()
    {
        musicSource.clip = Background;
    }
    void Update()
    { if (Input.GetKeyDown(KeyCode.Space))
        {
            musicSource.Play();
        }
    }
}
