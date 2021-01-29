using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //Variables
    public float forcaHorizontal = 15;
    public float forcaVertical = 10;
    public float tempoDeDestruicao;
    public float forcaHorizontalPadrao;

    // Start is called before the first frame update
    void Start()
    {
        forcaHorizontalPadrao = forcaHorizontal;
    }

    // Activated when in contact with a trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Compare the tags to see if it's an enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Disable the enemy script
            other.gameObject.GetComponent<Enemy>().enabled = false;

            // References the enemy's BoxColliders 
            BoxCollider2D[] boxes = other.gameObject.GetComponents<BoxCollider2D>();

            // Disable the enemy's box colliders
            foreach (BoxCollider2D box in boxes)
            {
                box.enabled = false;
            }

            // check if the enemy is on the left or right, so that the boost is applied correctly at the time of the attack
            if (other.transform.position.x < transform.position.x)
            {
                forcaHorizontal *= -1;
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaHorizontal, forcaVertical), ForceMode2D.Impulse);
                Destroy(other.gameObject, tempoDeDestruicao);

                forcaHorizontal = forcaHorizontalPadrao;
            }
            else if (other.transform.position.x > transform.position.x)
            {
                forcaHorizontal *= 1;
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaHorizontal, forcaVertical), ForceMode2D.Impulse);
                Destroy(other.gameObject, tempoDeDestruicao);
            }

        }

    }

}















