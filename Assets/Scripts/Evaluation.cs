using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Script to get the evaluation for each level in evey scenario and save it locally in saveEvaluation array. 
  This script will run only once while entering the player canvas. */  

public class Evaluation : MonoBehaviour
{    
    public SaveEvaluation[] saveEvaluation;    

    [System.Obsolete]
    private void Start()
    {
        for (int i = 0; i < 2; i++) //2 is no of scenarios, need to change
        {
            StartCoroutine(GoPlayer(i));
        }
    }

    [System.Obsolete]
    IEnumerator GoPlayer(int i)
    {
        WWWForm form = new WWWForm();
        int playerID = 1000; // need to retrieve from dbmanager
        form.AddField("id", playerID);

        WWW saveDetail = new WWW("http://localhost/gameProjSample/retrieve.php", form);
        yield return saveDetail;

        if (saveDetail.text[0] == '0')
        {
            //int.TryParse(saveDetail.text.Split('\t')[1], out int noOfLevels); //to convert string to int, as variable passed from dBFile is string

            for (int j = 0; j < saveEvaluation[i].levelEvaluation.Length; j++)
            {
                saveEvaluation[i].levelEvaluation[j] = saveDetail.text.Split('\t')[j + 2]; //0th and 1st index already occupied
                Debug.Log(saveEvaluation[i].levelEvaluation[j]);
            }
        }
        else
        {
            Debug.Log(saveDetail.text);
        }
    }
}
