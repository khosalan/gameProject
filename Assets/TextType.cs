using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextType : MonoBehaviour
{
    
    void Start()
    {
        string storyText = gameObject.GetComponent<Text>().text;
        gameObject.GetComponent<Text>().text = "";
        StartCoroutine(Type(storyText));
    }

    IEnumerator Type(string storyText)
    {        
        foreach (char letter in storyText.ToCharArray())
        {
            gameObject.GetComponent<Text>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }        
    }
    
}
