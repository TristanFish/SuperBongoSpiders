using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    int screenWidthLeft = 0;
    int screenWidthRight = 1920;

    public float cameraScrollSpeed = 0.05f;

    public int maxLeft = -1;
    public int maxRight = 1;

    
   


    // Start is called before the first frame update
    void Start()
    {
        screenWidthRight = Camera.main.pixelWidth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.x <= screenWidthLeft)
        {
            if (Camera.main.transform.position.x > maxLeft)
            {
                Camera.main.transform.Translate(-cameraScrollSpeed * (Time.deltaTime * 50.0f), 0, 0);
            }
        }

        if (Input.mousePosition.x >= screenWidthRight)
        {
            if (Camera.main.transform.position.x < maxRight)
            {
                Camera.main.transform.Translate(cameraScrollSpeed * (Time.deltaTime * 50.0f), 0, 0);
            }
        }
       
    }
}
