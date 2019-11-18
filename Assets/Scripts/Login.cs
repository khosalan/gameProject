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
    public Text alertPanelText;

    [System.Obsolete]
    private void Start()
    {        
        PlayerData data = SavePlayerData.LoadPlayerLogin();
        if (data != null)
        {
            emailField.text = data.email;
            passwordField.text = data.password;
            StartCoroutine(WaitTime());            
        }              
    }

    [System.Obsolete]
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1);
        CallLogin();
    }
    

    [System.Obsolete]
    public void CallLogin()
    {
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

}
