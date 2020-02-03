using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchAudio : MonoBehaviour
{
    private AudioClip song1;
    public AudioClip song2;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        song1 = audioSource.clip;
        Debug.Log(song1.name);
        Debug.Log(song2.name);

    }
    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            if(audioSource.clip.Equals(song1))
            {
                audioSource.clip = song2;
            }
            else if (audioSource.clip = song2)
            {
                audioSource.clip = song1;
            }
            audioSource.Play();
        }
    }
}
