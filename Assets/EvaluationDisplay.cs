using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This script is under selectionPanel of each scenarios.
 * For every level button under selecionPanel the ColorChange function will get executed while cilcking the button */
public class EvaluationDisplay : MonoBehaviour
{
    public int scenarioID;

    public GameObject content;
    public GameObject playerCanvas;
    public Button[] levels;
    
    //change color of selected button and to display the corresponding evaluation for that level
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
}
