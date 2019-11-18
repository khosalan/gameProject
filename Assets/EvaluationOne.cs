using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluationOne : MonoBehaviour
{    
    public GameObject content;    

    public Button[] levels; 

    public void ColorChange(int buttonId)
    {
        for(int i = 0; i < levels.Length; i++)
        {
            if (i == buttonId)
            {
                levels[i].GetComponent<Image>().color = Color.red;
                content.GetComponent<Text>().text = SaveManager.levelEvaluation[i];
            }                
            else
                levels[i].GetComponent<Image>().color = Color.white;
        }
    }
}
