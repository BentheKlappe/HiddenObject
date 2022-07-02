using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HOController : MonoBehaviour
{
    //getting object name and game text of each hidden object
    public static string objectName;
    public GameObject objectText;

    //If an object is clicked, destroy object and text
    private void OnMouseDown()
    {
        objectName = gameObject.name;
        Destroy(gameObject);
        Destroy(objectText);
    }
}
