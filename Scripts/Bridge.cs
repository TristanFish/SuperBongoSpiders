using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : InteractableObject
{
    private void Update()
    {
        BoxCollider2D boxcollider = GetComponent("BoxCollider2D") as BoxCollider2D;

        if (isRepaired == true)
        {
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.0f, -0.23f);
        }
    }

}
