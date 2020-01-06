using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject loginCanvas;
    public GameObject introCanvas;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            loginCanvas.SetActive(true);
            introCanvas.SetActive(false);
        }        
    }    
}
