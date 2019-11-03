using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    string unwanted1 = "dfvvvvvvvvvvvvdgr ergceewcw ee";
    public string email;
    string unwanted2 = "dvsdfbsfbsfbsfsfbgfgbfbfdbgfsdvsdfgerfgvs";
    string unwanted3 = "sdgvsefgfsdvrhthyrujdgrg";
    string unwanted4 = "grhgsrgergsdfttjthfgrg";
    string unwanted5;
    public string password;
    string unwanted6 = "tyteytery4y5y6yju7irbute trtrtuer r";

    //constructor
    public PlayerData(Login login)
    {
        unwanted5 = "fdgf fghdfghb hsf hsfhsfhs";
        email = login.emailField.text;
        password = login.passwordField.text;
        
    }
}
