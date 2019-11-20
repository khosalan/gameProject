using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public Text playerName;
    public GameObject menuCanvas;
    public GameObject playerCanvas;
    public GameObject profilePanel;
    public GameObject evaluationPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        if (DBManager.LoggedIn)
        {
            playerName.text = DBManager.userName.ToUpper();               
            
        }
        else
        {
            playerName.text = "Hello"; //remove this after completion of the project
            //SceneManager.LoadScene(0);            
        }        
    }

    public void OnClickPlayerLogo()
    {
        menuCanvas.SetActive(false);
        playerCanvas.SetActive(true);
        profilePanel.SetActive(true);
        evaluationPanel.SetActive(false);
    }


    public void PressExit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
		Application.Quit();
        #endif
    }


}
