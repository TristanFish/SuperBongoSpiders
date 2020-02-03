using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBridge : InteractableObject
{
    private bool isRotated = true;
    // Start is called before the first frame update
    IEnumerator dropBridge()
      {
        if (isRepaired == true)
        {
            yield return new WaitForSeconds(2.0f);
            transform.Rotate(0.0f, 0.0f, 90);
        }
        
      }

    // Update is called once per frame
    void Update()
    {
        if (isRepaired == true && isRotated == true)
        {
            StartCoroutine("dropBridge");
           
            isRotated = false;
        }
    }
}
