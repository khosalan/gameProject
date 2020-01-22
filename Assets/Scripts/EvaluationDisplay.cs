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
                levels[i].GetComponentInChildren<Text>().GetComponent<Text>().color = new Color(255f / 255f, 102f / 255f, 102f / 255f);
                content.GetComponent<Text>().text = playerCanvas.GetComponent<RetrieveRemarks>().remarks[buttonId];
            }
            else
                levels[i].GetComponentInChildren<Text>().GetComponent<Text>().color = new Color(255f / 255f, 227f / 255f, 0f / 255f);
        }
    }    
}
