using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    //Variables
    Animator anim;

    public float jumpForce;

    public int frutas;

    public GameObject frutaPrefab;

    public AudioClip[] audioClips;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    // Handles the interaction with the player, generating a certain number of fruits for him
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            anim.SetTrigger("Colidindo");

            if (frutas > 0)
            {
                GameObject tempFruta = Instantiate(frutaPrefab, transform.position, transform.rotation) as GameObject;
                tempFruta.GetComponent<Animator>().SetTrigger("Coletando");
                tempFruta.GetComponent<AudioSource>().Play();
                frutas -= 1;
                GameManager.gameManager.SetFrutas(1);
                Destroy(tempFruta, 1);
            }
            else
            {
                audioSource.clip = audioClips[1];
                AudioSource.PlayClipAtPoint(audioClips[1], transform.position);
                Destroy(gameObject);
            }
        }

    }
}


















