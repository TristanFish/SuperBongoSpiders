using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour
{
    public float panSpeed;
    public float screenWidthLeft;
    public float screenWidthRight;

    private Vector2 lastPosition;
    public Camera mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.transform.position.x > screenWidthRight)
        {
            mainCamera.transform.Translate(-panSpeed, 0.0f, 0.0f);
        }
        if (mainCamera.transform.position.x < screenWidthLeft)
        {
            mainCamera.transform.Translate(panSpeed, 0.0f, 0.0f);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            lastPosition = Input.mousePosition;
        }
        else if(Input.GetMouseButton(0))
        {
            if(mainCamera.transform.position.x <= screenWidthRight &&
                mainCamera.transform.position.x >= screenWidthLeft)
            {
                Vector2 delta = (Vector2)Input.mousePosition - lastPosition;
                mainCamera.transform.Translate(delta.x * -panSpeed, 0.0f, 0.0f);
                lastPosition = Input.mousePosition;
            }

        }
        
    }
}
