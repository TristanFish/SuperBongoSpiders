using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRenderWithoutLighting : MonoBehaviour
{
    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        camera.RenderWithShader(Shader.Find("Transparent"), "Opaque");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
