using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public InkStoryManager inkStoryManager;
    public GameObject exitCanvas;
    public GameObject levelMenu;
    public GameObject level;
    private bool _isPaused = false;

    public void OnClickPauseButton()
    {
        if(!_isPaused)
        {
            Time.timeScale = 0; //game paused
            _isPaused = true;
            gameObject.SetActive(true);
        }
    }

    public void OnClickResume()
    {
        if(_isPaused)
        {
            Time.timeScale = 1;
            _isPaused = false;
            gameObject.SetActive(false);
        }
    }

    public void OnClickRestart()
    {
        OnClickResume();
        inkStoryManager.StartStory();
    }

    public void OnClickExit()
    {
        exitCanvas.SetActive(false);
        OnClickResume();
        level.SetActive(false);
        levelMenu.SetActive(true);
    }
}
