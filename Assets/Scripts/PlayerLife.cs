using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    //Variables
    Animator anim;

    private bool vivo = true;

    public AudioClip deathSound;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        GameManager.gameManager.AtualizaHud();

    }

    // Function that takes care of the player's death
    public void PerdeVida()
    {
        if (vivo)
        {
            audioSource.clip = deathSound;
            audioSource.Play();
            vivo = false;
            anim.SetTrigger("Morreu");
            GameManager.gameManager.SetVidas(-1);
            gameObject.GetComponent<PlayerAttack>().enabled = false;
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }

    // If the player has lives left, the level is restarted
    public void Reset()
    {
        if (GameManager.gameManager.GetVidas() >= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene(4);
        }
    }





















}
