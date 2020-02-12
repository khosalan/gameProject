using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Login : MonoBehaviour
{

    public InputField emailField;
    public InputField passwordField;

    public Button loginButton;

    public GameObject loginPanel;
    public GameObject alertCanvas;
    public GameObject autoLoadingPanel;
    public GameObject loadingPanel;
    public GameObject updateCanvas;

    public Text alertPanelText;

    [System.Obsolete]
    private void Start()
    {
        StartCoroutine(GetVersion());                      
    }

    //Checking the current version of the game, whether it is the latest version

    [System.Obsolete]
    IEnumerator GetVersion()
    {
        WWW www = new WWW("http://localhost/gameProjSample/version.php");
        yield return www;

        if (www.error != null)
        {
            FindObjectOfType<AudioManager>().Play("Alertbox");
            alertPanelText.text = "Please check your connection";
            alertCanvas.SetActive(true);
        }
        else
        {
            if (www.text[0] == '0')
            {
                double.TryParse(www.text.Split('\t')[1], out double currentVersion);
                Debug.Log(currentVersion);
                if (currentVersion != DBManager.VersionNumber)
                {
                    FindObjectOfType<AudioManager>().Play("Alertbox");
                    updateCanvas.SetActive(true);
                    yield break;
                }
                PlayerData data = SavePlayerData.LoadPlayerLogin();
                if (data != null)
                {
                    emailField.text = data.email;
                    passwordField.text = data.password;
                    autoLoadingPanel.SetActive(true);
                    CallLogin();
                }
                //yield return StartCoroutine(WaitTime());                
            }
        }
    }

    /*[System.Obsolete]
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1);
        CallLogin();
    }*/
    

    [System.Obsolete]
    public void CallLogin()
    {
        if (!autoLoadingPanel.active)
        {
            loadingPanel.SetActive(true);
        }
        StartCoroutine(GoLogin());
    }

    [System.Obsolete]
    IEnumerator GoLogin()
    {
        WWWForm form = new WWWForm();        
        form.AddField("email", emailField.text);
        form.AddField("password", passwordField.text);        

        WWW www = new WWW("http://localhost/gameProjSample/login.php", form);
        
        yield return www;
        loadingPanel.SetActive(false);
        autoLoadingPanel.SetActive(false);

        if(www.error != null)
        {
            FindObjectOfType<AudioManager>().Play("Alertbox");
            alertPanelText.text = "Please check your connection";
            alertCanvas.SetActive(true);
        }
        else
        {
            if (www.text[0] == '0')
            {
                SavePlayerData.SavePlayerLogin(this);
                DBManager.userName = www.text.Split('\t')[1];
                                
                SceneManager.LoadScene(1);
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Alertbox");
                alertPanelText.text = www.text;
                alertCanvas.SetActive(true);
            }
        }        

    }

    public void VerifyInputs()
    {
        loginButton.interactable = (emailField.text.Length >= 8 && passwordField.text.Length >= 8);
    }

    public void OnClickRegister()
    {
        Application.OpenURL("www.google.lk");
    }

    public void OnClickForgotPassword()
    {
        Application.OpenURL("www.google.lk");
    }

    public void OnClickUpdate()
    {
        Application.OpenURL("www.google.lk");
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
