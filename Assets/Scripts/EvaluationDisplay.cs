using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* This script is under selectionPanel of each scenarios.
 * For every level button under selecionPanel the ColorChange function will get executed while cilcking the button */
public class EvaluationDisplay : MonoBehaviour
{
    public int scenarioID;
    public int noOfLevels;

    public GameObject content;    
    public Button[] levels;
    
    public string[] remarks;

    [System.Obsolete]
    void Start()
    {
        remarks = new string[noOfLevels];
        for (int i = 1; i <= noOfLevels; i++)
        {
            StartCoroutine(GetEvaluation(i));
        }
    }

    [System.Obsolete]
    IEnumerator GetEvaluation(int i)
    {
        WWWForm form = new WWWForm();

        int playerID = 1000; // need to retrieve from dbmanager
        int levelID = i;

        form.AddField("playerID", playerID);
        form.AddField("scenarioID", scenarioID+1); //as the array index starts at zero,to make it equal to scenario in DB added one 
        form.AddField("levelID", levelID);

        WWW saveDetail = new WWW("http://localhost/gameProjSample/retrieve.php", form);
        yield return saveDetail;

        if (saveDetail.text[0] == '0')
        {
            remarks[i - 1] = saveDetail.text.Split('\t')[1];
        }
        else
        {
            Debug.Log(saveDetail.text);
        }
    }

    //change color of selected button and to display the corresponding evaluation for that level
    public void ColorChange(int buttonId)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if (i == buttonId)
            {
                levels[i].GetComponentInChildren<Text>().GetComponent<Text>().color = new Color(255f / 255f, 102f / 255f, 102f / 255f);
                content.GetComponent<Text>().text = remarks[buttonId];
            }
            else
                levels[i].GetComponentInChildren<Text>().GetComponent<Text>().color = new Color(255f / 255f, 227f / 255f, 0f / 255f);
        }
    }    
}
