using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;

[System.Serializable]
public class PlayerData
{    
    public string email;    
    public string password;    

    //constructor
    public PlayerData(Login login)
    {       
        email = login.emailField.text;
        password = login.passwordField.text;
    }
}
