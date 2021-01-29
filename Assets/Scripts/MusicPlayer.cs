using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //Variable
    private static MusicPlayer musicPlayer;


    void Awake()
    {
        //Makes music persist from scene to scene
        if (musicPlayer == null)
        {
            musicPlayer = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
