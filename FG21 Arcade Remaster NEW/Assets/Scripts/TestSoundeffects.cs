using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSoundeffects : MonoBehaviour
{
    public AudioClip music;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(music, 1F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
