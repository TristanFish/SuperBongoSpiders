using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // public SpiderSwarm
    SpiderSwarm spiderType1;
    Vector2 movePosition;

    // change this to selection *******************
    public SpiderSwarm selectedSpiders;

    //
    public InteractableObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if(Input.mousePosition.x < 550 && Input.mousePosition.y < 150)
        {
            Debug.Log("Clicked Box");
            return;
        }
        // MOUSE INPUT & MOUSE POSITION
        if(Input.GetMouseButtonDown(0))
        { 
            movePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //Debug.Log(movePosition);

            // need to check if the object you raycast to has an <InteractableObject> attached to it
            // if you click on a certain object, interact with it
           

            RaycastHit2D r = Physics2D.Raycast(movePosition, new Vector2(0.0f, 1.0f), 1.0f);
            selectedSpiders.RecallSpiders(movePosition);
            if(r.collider.GetComponent<InteractableObject>() != null)
            {
                selectedObject = r.collider.GetComponent<InteractableObject>();
                if (!selectedObject.isRepaired && (selectedObject.AcceptedSpiders == selectedSpiders.spiderJob))
                {
                    selectedSpiders.currentTarget = selectedObject;
                }
            } else
            {
                selectedSpiders.currentTarget = null;
                selectedObject = null;
            }
        }


        if (Input.GetMouseButtonDown(1))
        {
            selectedSpiders.CreateWeb();

            if(selectedObject != null)
            { 
                selectedSpiders.RecallSpiders((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
                selectedObject.RemoveAllSpiders();
                selectedObject = null;
            }
        }

        MoveSpider(selectedSpiders, movePosition);
        
    }

    void MoveSpider(SpiderSwarm spiders_, Vector2 movePosition_)
    {
        if (spiders_.spiders.Count > 0)
        {
            spiders_.Move(movePosition_);
        }
    }
}
