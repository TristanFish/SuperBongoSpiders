using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpiders : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] spiders;
    Transform currentPoint;

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        currentPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

    }
    public void SpawnSpiderBuilder()
    {
        Instantiate(spiders[0], new Vector2(currentPoint.position.x, currentPoint.position.y), Quaternion.identity);
    }


}
