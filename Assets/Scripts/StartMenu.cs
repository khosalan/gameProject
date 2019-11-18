using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public Text playerName;    
    

    // Start is called before the first frame update
    void Start()
    {
        if (DBManager.LoggedIn)
        {
            playerName.text = DBManager.userName.ToUpper();               
            
        }
        else
        {
            //playerName.text = DBManager.userName.ToUpper(); //remove this after completion of the project
            //SceneManager.LoadScene(0);
            Debug.Log("in else");
        }        
    }
        
    

    public void PressLogout()
    {
        //DBManager.LogOut();
        SceneManager.LoadScene(0);
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
