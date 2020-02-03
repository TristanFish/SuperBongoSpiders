using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpiderType { Silkers, Attackers, Builders, Eaters };

public class SpiderSwarm : MonoBehaviour
{
    public List<Spider> spiders = new List<Spider>();
    
    public Spider spiderType;
    [Tooltip("Make sure spiderJob matches the spiderType above!!!")]
    public SpiderType spiderJob;

    public bool isSelected;
    private Vector2 targetPosition;
    //Currently selected Object that the spiders want to interact with
    public InteractableObject currentTarget;
    //distance needed for the spiders to jump to object
    public float attachDistance;
    //force spiders are launched when they get attached to an object
    public float attachForce;

    public GameObject webLadder;
    private GameObject currentLadder;

    void Start()
    {
        // TESTING
        /*AddSpider(new Vector2(Random.Range(-10.0f, 0.0f), 0.0f));
        AddSpider(new Vector2(Random.Range(-10.0f, 0.0f), 0.0f));
        AddSpider(new Vector2(Random.Range(-10.0f, 0.0f), 0.0f));
        AddSpider(new Vector2(Random.Range(-10.0f, 0.0f), 0.0f));*/

    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(targetPosition);
        foreach (Spider s in spiders)
        {
            s.Move(targetPosition);
        }

        if (currentTarget != null)
        {
            float distanceModifier = 1.0f;
            if(currentTarget as Bridge != null)
            {
                distanceModifier = 5.5f;
                Debug.Log("Distance Modified");
            }
            foreach (Spider s in spiders)
            {
                if (Vector2.Distance(s.transform.position, currentTarget.transform.position) < attachDistance * distanceModifier)
                {
                    s.Attach(currentTarget, attachForce);
                }
            }
        }
    }

    // change spider type thing later ************
    // add spider
    public void AddSpider(Vector2 spawnPosition)
    {
        // 
        GameObject s = Instantiate(spiderType.gameObject, (Vector3)spawnPosition, transform.rotation);
        spiders.Add(s.GetComponent<Spider>());
    }

    public void AddSpiders(int numSpiders_, float minRangeX_, float maxRangeX_, float y_)
    {
        for(int i= 0; i < numSpiders_; i++)
        {
            AddSpider(new Vector2(Random.Range(minRangeX_, maxRangeX_), y_));
        }
    }
    

    // remove spider 
    public void RemoveSpider(Spider spider_)
    {
        Destroy(spider_.gameObject);
        spiders.Remove(spider_);
    }


    // Iterates through all spiders in list and performs their action
    public void Action()
    {
        if (spiders != null)
        {
            foreach (Spider spider in spiders)
            {
                spider.Action();
            }
        }
    }

    // Iterates through all spiders in list and moves
    public void Move(Vector2 mousePosition_)
    {
        targetPosition = mousePosition_;
        if (spiders != null)
        {
            int counter = 1;
            foreach (Spider spider in spiders)
            {
                spider.Move(targetPosition);
                counter++;
            }
        }
    }

    public void Stop()
    {
        if (spiders != null)
        {
            foreach (Spider spider in spiders)
            {
                spider.Stop();
            }
        }
    }

    public void OnSelect()
    {
        isSelected = true;
        foreach(Spider s in spiders)
        {
            s.isSelected = true;
        }
        Stop();
    }

    public void OnDeselect()
    {
        isSelected = false;
        foreach(Spider s in spiders)
        {
            s.isSelected = false;
            s.isMoving = false;
            s.rb.velocity = new Vector2(0.0f, 0.0f);
        }
    }
    
    //Any spiders that are currently doing a task will be recalled back to the swarm
    public void RecallSpiders(Vector2 mousePosition)
    {
        foreach(Spider s in spiders)
        {
            s.SetIsBusy(false);
        }
        Move(mousePosition);
    }

    public void CreateWeb()
    {
        if(currentLadder != null)
        {
            GameObject.Destroy(currentLadder);
        }

        if((spiderJob == SpiderType.Silkers) && isSelected)
        {
            currentLadder = Instantiate(webLadder, new Vector3(AverageXPos(), LowestYPos(), 0.0f), Quaternion.identity);
            currentLadder.transform.localScale = new Vector3(1.0f, spiders.Count /2, 1.0f);

            Debug.Log("CreateWeb");
        }
    }

    private float AverageXPos()
    {
        float avg = 0;

        for(int i = 0; i < spiders.Count; i++)
        {
            avg += spiders[i].transform.position.x;
        }
        avg = avg / spiders.Count;

        return avg;
    }

    private float LowestYPos()
    {
        float low = 1000;

        foreach(Spider s in spiders)
        {
            if(s.transform.position.y < low)
            {
                low = s.transform.position.y;
            }
        }
        return low;
    }
}
