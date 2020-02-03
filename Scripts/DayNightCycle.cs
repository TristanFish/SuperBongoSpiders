using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public bool[] Planents;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Planents[0])
        {
            transform.Rotate(0.0f, 0.0f, 0.010f * Time.deltaTime * 180.0f);
        }
        if (Planents[1])
        {
            transform.Rotate(0.0f, 0.0f, -0.010f * Time.deltaTime * 180.0f);
        }
        if (Planents[2])
        {
            transform.Rotate(0.0f, 0.0f, 0.040f * Time.deltaTime * 180.0f);
        }
    }
}
