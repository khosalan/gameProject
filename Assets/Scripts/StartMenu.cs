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
            playerName.text = "Hi " + DBManager.userName.ToUpper() + " !";
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void PressLogout()
    {
        //DBManager.LogOut();
        SceneManager.LoadScene(0);
    }

    
}
