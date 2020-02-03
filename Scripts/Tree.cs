using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : InteractableObject
{
    // PLEASE CHANGE THIS LATER BEN ****************************************
    public SpiderSwarm attackerSpiderSwarm;
    public int numOfAttackSpiders;

    // once you delay, spawn attacker spiders
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2.0f);
        smoke.Play();
        attackerSpiderSwarm.AddSpiders(numOfAttackSpiders, transform.position.x - 0.5f, transform.position.x + 0.5f, 0.0f);
    }

}
