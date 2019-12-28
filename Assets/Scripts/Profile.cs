using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    public Text playerName;
    // Start is called before the first frame update
    void Start()
    {
        playerName.text = DBManager.userName.ToUpper();
    }   
}
