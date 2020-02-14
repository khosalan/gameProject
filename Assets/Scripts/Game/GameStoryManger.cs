using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStoryManger : MonoBehaviour
{
    public InkStoryManager inkStoryManager;

    public GameObject dialogCanvas;
    public GameObject homeCanvas;

    public GameObject backgroundParent;
    public GameObject levelCanvas;

    private void Awake()
    {
        inkStoryManager.AddTagProcessor("background", delegate (string value) {
            SwitchToBackground(value);
        });

        inkStoryManager.storyEndAction = delegate
        {
            BackToMenu();
        };
    }

    public void OnClickLevel()
    {
        dialogCanvas.SetActive(true);
        homeCanvas.SetActive(false);
        inkStoryManager.StartStory();        
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(levelCanvas.GetComponent<BackToMenu>().currentScene);
        
    }

    void SwitchToBackground(string text)
    {
        int childCount = backgroundParent.transform.childCount;
        for (int i = childCount; i > 0; i--)
        {            
            var background = backgroundParent.transform.GetChild(i - 1).gameObject;
            background.SetActive(background.name == text);
        }
    }

    
}
