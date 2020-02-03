using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStretcher : MonoBehaviour
{
    Camera cam;
    public float height = 1f;
    public float width = 1f;

    // Use this for initialization
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //stretch view//
        cam.ResetProjectionMatrix();
        var m = cam.projectionMatrix;

        m.m11 *= height;
        m.m00 *= width;
        cam.projectionMatrix = m;
    }
}
