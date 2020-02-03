using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    public bool isRepaired = false;

    public int requiredSpiders;
    
    public List<Spider> currentSpiders;

    public Animator animator;

    public AudioSource audio;

    public ParticleSystem smoke;

    public SpiderType AcceptedSpiders;

    BoxCollider2D boxCollider;

    public GameObject identifier;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        smoke = GetComponentInChildren<ParticleSystem>();
        audio = GetComponent<AudioSource>();
    }

    public void AddSpider(Spider spider)
    {
        if(isRepaired)
        {
            return;
        }
        if (currentSpiders.Count < requiredSpiders)
        {
            currentSpiders.Add(spider);
            spider.SetIsBusy(true);
        }

        if(currentSpiders.Count >= requiredSpiders)
        {
            Repair();
        }
    }

    public void RemoveAllSpiders()
    {
        foreach(Spider s in currentSpiders)
        {
            s.SetIsBusy(false);
        }
        currentSpiders.Clear();
    }

    public void Repair()
    {
        identifier.SetActive(false);

        if (smoke != null)
        {
            StartCoroutine("Delay");
        }

        isRepaired = true;
        animator.SetBool("isRepaired", true);
        RemoveAllSpiders();
        if (audio != null)
        {
            audio.Play();
        }
    }

    
    IEnumerator Delay()
    {
         yield return new WaitForSeconds(2.0f);
        smoke.Play();
    }
}
    