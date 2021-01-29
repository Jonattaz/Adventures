using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables
    public  static GameManager gameManager;

    public int vidas = 2;
    public int frutas = 0;


    private void Start()
    {
        AtualizaHud();
    }

    // This function starts before the object starts on the scene
    private void Awake()
    {
        //Serve para garantir que tenha apenas um game manager em cena
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update the text of life and the text of fruits
    public void AtualizaHud()
    {
        GameObject.Find("VidasText").GetComponent<Text>().text = vidas.ToString();
        GameObject.Find("FrutasText").GetComponent<Text>().text = frutas.ToString();
    }


    // Defines the number of lives
    public void SetVidas(int vida)
    {
        vidas += vida;
        if ( vidas >= 0)
        {
            AtualizaHud();
        }
        
    }

    // Take the number of lives
    public int GetVidas()
    {
        return vidas;
    }

    public void SetFrutas(int fruta)
    {
        frutas += fruta;
        // If the player collects more than a hundred fruits, he gains a life 
        if (frutas >= 100)
        {
            frutas = 0;
            vidas += 1;
        }

        AtualizaHud();
    }


    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            vidas = 2;
            frutas = 0;
        }
    }
}















