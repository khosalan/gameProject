using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public InputField nameField;
    public InputField emailField;
    public InputField passwordField;
    public InputField conPasswordField;

    public GameObject loginPanel;
    public GameObject registerPanel;
    public GameObject alertPanel;
    public GameObject successPanel;

    public Button registerButton;

    public Text alertText;

    [System.Obsolete]
    public void callRegister()
    {
        StartCoroutine(Register());
    }

    [System.Obsolete]
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("email", emailField.text);
        form.AddField("password", passwordField.text);

        WWW www = new WWW("http://localhost/gameProjSample/register.php",form);
        yield return www;
        if (www.text == "0")
        {
            successPanel.SetActive(true);
            Debug.Log("User created successfully");
            nameField.text = null;
            emailField.text = null;
            passwordField.text = null;
            conPasswordField.text = null;
        }
        else
        {
            if (www.error != null)
            {
                alertText.text = "Check Your Connection";
                alertPanel.SetActive(true);
            }
            else
            {
                alertText.text = www.text;
                alertPanel.SetActive(true);
                Debug.Log("User creation failed " + www.text);
            }
              
        }
    }

    public void VerifyInputs()
    {
        registerButton.interactable = (nameField.text.Length >= 8 && emailField.text.Length >= 8 && passwordField.text.Length>=8 && passwordField.text == conPasswordField.text);
    }
    
}
