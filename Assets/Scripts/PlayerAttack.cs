using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Variables
    public Animator anim;

    public float intervaloDeAtaque;
    private float proximoAtaque;

    public AudioClip spinSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > proximoAtaque)
        {
            Atacando();
        }

    }

    // Method responsible for activating the animation of the attack and the delay time between one attack and another
    void Atacando()
    {
        audioSource.clip = spinSound;
        audioSource.Play();
        anim.SetTrigger("Ataque");
        proximoAtaque = Time.time + intervaloDeAtaque;
    }

}
























