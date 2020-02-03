using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderTrigger : MonoBehaviour
{

    private BoxCollider2D boxCol;
    private Rigidbody2D rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb = collision.GetComponent<Rigidbody2D>();
        boxCol = collision.GetComponent<BoxCollider2D>();
        if(collision.CompareTag("Boulder"))
        {
            StartCoroutine("Wait");
            boxCol.enabled = true;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        rb.bodyType = RigidbodyType2D.Static;
    }
}
