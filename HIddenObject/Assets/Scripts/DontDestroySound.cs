using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroySound : MonoBehaviour
{
    static DontDestroySound Instance;

    private void Awake()
    {
        //Making the sound persistent - and making sure it doens't play twice
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else 
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

    }
}
