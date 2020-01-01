using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject loginCanvas;
    public GameObject introCanvas;
    public void hideIntro()
    {
        loginCanvas.SetActive(true);
        introCanvas.SetActive(false);
    }
}
