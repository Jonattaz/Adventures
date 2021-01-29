using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    //Variables
    Animator anim;
   
    CircleCollider2D ColliderFruit;
    
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
        ColliderFruit = gameObject.GetComponent<CircleCollider2D>();
    }

    //When the fruit collides with the player, it is collected by him
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            GameManager.gameManager.SetFrutas(1);
            anim.SetTrigger("Coletando");
            ColliderFruit.enabled = false;
            Destroy(gameObject, 1);

        }    
        
    }
}














