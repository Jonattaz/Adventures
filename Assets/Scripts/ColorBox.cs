using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Quando este script é colocado num objeto, e caso este não tenha um sprite renderer, o sprite renderer será adicionado
[RequireComponent(typeof(SpriteRenderer))] // Isso é um atributo da Unity
public class ColorBox : MonoBehaviour
{
    [SerializeField] SpriteRenderer renderer;

    // Tempo que leva para trocar de cor
    [SerializeField] float timer = 0.1f;

    // Stop serve para controlar quando o bloco deve parar de piscar
    [SerializeField] bool stop = false;

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
            //Array de cores que vai de 0 a 5
            Color[] colors = new Color[6];

            // Váriavel color que armazena a cor final, para que essa possa ser passada para o personagem
            Color finalColor;

            // Aqui é onde se adiciona as cores
            colors[0] = Color.blue;
            colors[1] = Color.red;
            colors[2] = Color.green;
            colors[3] = Color.cyan;
            colors[4] = Color.magenta;
            colors[5] = Color.yellow;


            if(!stop)
                renderer.color = colors[Random.Range(0, colors.Length)];
            else{
                finalColor = renderer.color;
            }
            
            timeChecker = 0f;
        }
    }
}









