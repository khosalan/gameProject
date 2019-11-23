using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{    
    public GameObject menuCanvas;
    public GameObject playerCanvas;
    public GameObject profilePanel;
    public GameObject evaluationPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        //if not logged in goto login scene
        if (!DBManager.LoggedIn)
        {
            //SceneManager.LoadScene(0);
            Debug.Log("Not logged in");
        }                
    }

    //When clicking the player logo need to select profile view of the player and change the colour of the profile button
    public void OnClickPlayerLogo()
    {
        menuCanvas.SetActive(false);
        playerCanvas.SetActive(true);
        profilePanel.SetActive(true);
        evaluationPanel.SetActive(false);

        playerCanvas.GetComponent<PlayerManager>().profileButton.GetComponent<Image>().color = Color.red;
        playerCanvas.GetComponent<PlayerManager>().evaluationButton.GetComponent<Image>().color = Color.white;
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
