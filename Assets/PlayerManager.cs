using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject content;
    public Button[] scenarioButtons;
    public GameObject[] selectionPanel;
    

    /*public void OnClickEvaluation()
    {
        scenarioOne.GetComponent<Image>().color = Color.red;
        scenarioTwo.GetComponent<Image>().color = Color.white;
        scenarioThree.GetComponent<Image>().color = Color.white;        
    }*/   


    [System.Obsolete]
    public void Retrieve(string tableName)
    {
        StartCoroutine(GoPlayer(tableName));
    }

    [System.Obsolete]
    IEnumerator GoPlayer(string tableName)
    {
        WWWForm form = new WWWForm();
        int test = 1;        
        form.AddField("id", test);
        form.AddField("tableName", tableName);

        WWW saveDetail = new WWW("http://localhost/gameProjSample/save.php", form);
        yield return saveDetail;

        if (saveDetail.text[0] == '0')
        {            
            SaveManager.levelEvaluation = new string[3]; //need to change 3, need to get it from savemanager

            for(int i = 0; i < 3; i++)
            {
                SaveManager.levelEvaluation[i] = saveDetail.text.Split('\t')[i + 1];
            }
        }
        else
        {
            Debug.Log(saveDetail.text);
        }
    }

    public void ColorChange(int id)
    {
        for (int i = 0; i < scenarioButtons.Length; i++)
        {
            if (i == id)
            {
                scenarioButtons[i].GetComponent<Image>().color = Color.red;
                selectionPanel[i].SetActive(true);
                //selectionPanel[i].GetComponent<EvaluationOne>().ColorChange(0);
            }
            else
            {
                scenarioButtons[i].GetComponent<Image>().color = Color.white;
                selectionPanel[i].SetActive(false);
            }                

            //content.GetComponent<Text>().text = "";
        }

    }
}
