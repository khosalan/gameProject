using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrieveRemarks : MonoBehaviour
{
    public int scenarioID;
    public int noOfLevels;
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

        int playerID = DBManager.playerID; 
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
