using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvaluationDisplay : MonoBehaviour
{
    public int scenarioID;

    public GameObject content;
    public GameObject playerCanvas;
    public Button[] levels;   

    public void ColorChange(int buttonId)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if (i == buttonId)
            {
                levels[i].GetComponent<Image>().color = Color.red;
                content.GetComponent<Text>().text = playerCanvas.GetComponent<Evaluation>().saveEvaluation[scenarioID].levelEvaluation[buttonId];                
            }
            else
                levels[i].GetComponent<Image>().color = Color.white;
        }
    }

    /*public void DisplayResult(int buttonId)
    {
        content.GetComponent<Text>().text = playerLogo.GetComponentInChildren<Evaluation>().saveEvaluation[0].levelEvaluation[buttonId];
        //Debug.Log(playerLogo.GetComponentInChildren<Evaluation>().saveEvaluation[1].levelEvaluation[1]);
    }*/
}
