using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HOController : MonoBehaviour
{
    //getting object name and game text of each hidden object
    public static string objectName;
    public GameObject objectText;

    //sounds
    public AudioSource audioSource;
    public AudioClip itemClicked;


    private void Start()
    {
        //Gets the audioSource from the AudioManager
        audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();
    }

    //If an object is clicked, destroy object and text
    private void OnMouseDown()
    {
        objectName = gameObject.name;
        Destroy(gameObject);
        Destroy(objectText);

        //Play a sound
        audioSource.PlayOneShot(itemClicked);
    }

}
