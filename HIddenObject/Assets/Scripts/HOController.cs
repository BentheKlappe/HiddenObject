using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HOController : MonoBehaviour
{
    //getting object name and game text of each hidden object
    public static string objectName;
    [Tooltip("Select the UI textbox that corresponds to this item")]
    public GameObject objectText;

    //sounds
    public AudioSource audioSource;
    public AudioClip itemClicked;

    //referencing scoremanager 
    ScoreManager scoreManager;

    private void Start()
    {
        //Gets the audioSource from the AudioManager
        audioSource = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioSource>();

        //Gets the reference to the script 'scoremanager'
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    //If an object is clicked, destroy object and text
    private void OnMouseDown()
    {
        objectName = gameObject.name;
        Destroy(gameObject);
        Destroy(objectText);

        //Play a sound
        audioSource.PlayOneShot(itemClicked);

        //add the points to the total score
        scoreManager.addPoints();
    }

}
