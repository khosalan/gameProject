using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStoryManger : MonoBehaviour
{
    public InkStoryManager inkStoryManager;
    public GameObject dialogCanvas;
    public GameObject homeCanvas;

    private void Awake()
    {
        
    }

    public void OnClickLevel()
    {
        inkStoryManager.StartStory();
        dialogCanvas.SetActive(true);
        homeCanvas.SetActive(false);
    }
}
