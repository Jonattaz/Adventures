using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Quando este script é colocado num objeto, e caso este não tenha um sprite renderer, o sprite renderer será adicionado
[RequireComponent(typeof(SpriteRenderer))] // Isso é um atributo da Unity
public class ColorBox : MonoBehaviour
{
    [SerializeField] SpriteRenderer renderer;
    [SerializeField] float timer = 0.1f;

    // Checa quanto tempo passou desde a última vez que a cor foi trocada
    private float timeChecker = 0;

    // Start is called before the first frame update
    void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        ColorChange();
    }

    // Método que controla a troca de cores
    void ColorChange()
    {

        timeChecker += Time.deltaTime;
        if (renderer != null && timeChecker >= timer)
        {
            Color newColor = new Color(
                Random.value,
                Random.value,
                Random.value
            );

            renderer.color = newColor;
            timeChecker = 0f;
        }
    }
}









