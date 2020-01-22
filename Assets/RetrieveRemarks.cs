using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrieveRemarks : MonoBehaviour
{
    public int scenarioID;
    public string[] remarks;
    void Start()
    {        
        for(int i = 1; i <= remarks.Length; i++)
        {
            StartCoroutine(GetEvaluation(i));
        }
    }

    IEnumerator GetEvaluation(int i)
    {
        WWWForm form = new WWWForm();

        int playerID = 1000; // need to retrieve from dbmanager
        int levelID = i;

        form.AddField("playerID", playerID);
        form.AddField("scenarioID", scenarioID);
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

   
}
