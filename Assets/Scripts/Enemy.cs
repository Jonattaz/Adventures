using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Variables
    public float speed;
    public float impactJump = 700;

    Rigidbody2D enemyRb;
    
    bool facingRight = false;
    bool InGround = false;
    
    Transform groundCheck;

    AudioSource audioSource;

   
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        enemyRb = gameObject.GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("EnemyGroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the enemy is on the ground, checking the position of the EnemyGroundCheck if it is on the ground layer
        InGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (!InGround)
        {
            speed *= -1;
        }
    }


    private void FixedUpdate()
    {
        enemyRb.velocity = new Vector2(speed, enemyRb.velocity.y);

        // Make the enemy switch sides on the screen based on speed
        if (speed > 0 && !facingRight)
        {
            Flip();

        } 
            else if(speed < 0 && facingRight)
        {
            Flip();
        }
    }


    // Controls the flip movement
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();

            // Disables the enemy's boxColliders when hit by the player
            BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }

            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
;
            // Turns the enemy upside down when hit and when it leaves the scene it is destroyed
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, impactJump));
            speed = 0;
            transform.Rotate(new Vector3(0, 0, -180));
            Destroy(gameObject, 3);

        }
    }

    // When the enemy collides with the player, deal damage to him
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerLife>().PerdeVida();
        }
    }




}




























