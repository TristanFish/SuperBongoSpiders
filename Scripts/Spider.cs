using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{

    // Variables
    public bool isSelected;
    protected int currentLevel;
    [SerializeField]
    protected bool isBusy;
    public Rigidbody2D rb;
    public bool isMoving = false;
    protected bool isGrounded;

    protected Animator animator;
    protected GameManager manager;
    protected GameObject gameManager;

    private float spiderSpeed;
    private AudioSource blop;

    public float jumpPower;

    public Vector2 spiderVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spiderVelocity = new Vector2();
        animator = gameObject.GetComponent<Animator>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        manager = gameManager.GetComponent<GameManager>();
        blop = gameObject.GetComponent<AudioSource>();

        // SET DEFAULT JUMPPOWER AND SPIDERSPEED??
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving && isSelected)
        {
            rb.velocity = new Vector2(spiderVelocity.normalized.x * spiderSpeed, rb.velocity.y);
            animator.SetInteger("Movement", 1);
        }
        else
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
            animator.SetInteger("Movement", 0);
        }
        spiderSpeed = Random.Range(1.0f, 3.7f);
    }

    // Move to the position of the mouse
    public void Move(Vector2 mousePosition_)
    {
        //if (mousePosition_.y > -2.5) // && manager.buildersSelected == true ----- Ben cut this out 
        {
            isMoving = true;
            spiderVelocity.x = mousePosition_.x - transform.position.x;

            rb.velocity = new Vector2(spiderVelocity.normalized.x * spiderSpeed, rb.velocity.y);
        }
    }

    // return position (Vector2)
    public Vector2 GetPosition()
    {
        return (Vector2)transform.position;
    }

    // return velocity (Vector2)
    public Vector2 GetVelocity()
    {
        return rb.velocity;
    }

    // SETTERS---------------
    public void SetIsBusy(bool isBusy_)
    {
        isBusy = isBusy_;
    }

    // Stops the spider's movement
    public void Stop()
    {
        // zero vector
        rb.velocity = new Vector2();
        isMoving = false;
    }




    // Collision
    // when a spider collides 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            Debug.Log("TREE");
            // access interactable object class from the collision 
        }
        if(collision.gameObject.CompareTag("EndChecker"))
        {
            collision.GetComponent<EndGame>().numSpiders++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndChecker"))
        {
            collision.GetComponent<EndGame>().numSpiders--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.CompareTag("SilkerSpider") || 
            collision.gameObject.CompareTag("AttackerSpider") || 
            collision.gameObject.CompareTag("BuilderSpider") ||
            collision.gameObject.CompareTag("EaterSpider")) && isGrounded && isSelected)
        {
            Vector2 newForce = new Vector2(spiderVelocity.normalized.x, 1.0f);
            blop.pitch = Random.Range(0.5f, 2.0f);
            blop.Play();
            jumpPower = Random.Range(1.5f, 3.7f);

            rb.AddForce(newForce * jumpPower * rb.mass, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void Action()
    {
        
    }

    public void Attach(InteractableObject io, float attachForce)
    {
        if (!isBusy)
        {
            Debug.Log(rb.velocity);
            io.AddSpider(this);
            Debug.Log(rb.velocity);
            isBusy = true;
            Debug.Log("Attach");
            //rb.AddForce(new Vector2(attachForce * io.transform.position.x * Mathf.Sin(45), attachForce * io.transform.position.y * Mathf.Cos(45)));
        }
    }

}
