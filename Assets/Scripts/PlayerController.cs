using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float speed;
    public float jumpForce;

    private Rigidbody2D playerRb;

    private bool facingRight = true;
    private bool jump = true;
    private bool inGround = false;

    private Animator anim;


    private Transform groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        // linking variables to their component type
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("GroundCheck");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is on the ground, checking the position of the groundcheck if it is on the layer ground
        inGround = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        // Makes the player jump if he is on the ground
        if (Input.GetButtonDown("Jump") && inGround)
        {
            jump = true;
            anim.SetTrigger("Pulou");
        }

    }
    private void FixedUpdate()
    {
        // Move the player on the horizontal axis and activate the animation
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Velocidade", Mathf.Abs(horizontalInput));
        playerRb.velocity = new Vector2(horizontalInput * speed, playerRb.velocity.y);


        // allows the player to turn the character from left to right
        if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }

        if (jump)
        {
            playerRb.AddForce(new Vector2(0, jumpForce));
            jump = false;
        }

    }

    // Controls the player's turning movement
    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


}


























