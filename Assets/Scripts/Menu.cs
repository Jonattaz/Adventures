using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadPhase(int cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void ExitGame()
    {
        Application.Quit();
        
    }
   
}
