using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderSound : MonoBehaviour
{
    private Vector3 currentPosition;
    private AudioSource movingBoulder;
    public GameObject boulder;
    
    
    // Start is called before the first frame update
   void playAudio()
    {
        boulder.GetComponent<AudioSource>();
        movingBoulder.Play(0);
        Debug.Log("boulder is moving");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (currentPosition != gameObject.transform.position)
        {
            playAudio();
        }
        currentPosition = gameObject.transform.position;
    }
}
