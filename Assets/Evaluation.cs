using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Evaluation : MonoBehaviour
{    
    public SaveEvaluation[] saveEvaluation;
    public GameObject playerCanvas;

    [System.Obsolete]
    private void Start()
    {
        for (int i = 0; i < 2; i++) //2 is no of scenarios, need to change
        {
            StartCoroutine(GoPlayer(saveEvaluation[i].dBFileName, i));
        }
    }

    [System.Obsolete]
    IEnumerator GoPlayer(string dBFileName,int i)
    {
        WWWForm form = new WWWForm();
        int playerID = 1; // need to retrieve from dbmanager
        form.AddField("id", playerID);

        WWW saveDetail = new WWW("http://localhost/gameProjSample/" + dBFileName + ".php", form);
        yield return saveDetail;
        int noOfLevels;

        if (saveDetail.text[0] == '0')
        {
            int.TryParse(saveDetail.text.Split('\t')[1], out noOfLevels);            

            for (int j = 0; j < noOfLevels; j++)
            {
                saveEvaluation[i].levelEvaluation[j] = saveDetail.text.Split('\t')[j + 2];
                //Debug.Log(saveEvaluation[i].levelEvaluation[j]);
            }            
        }
        else
        {
            Debug.Log(saveDetail.text);
        }
    }
    
    public void OnCLickEvaluation()
    {
        playerCanvas.GetComponent<PlayerManager>().ColorChange(0);
    }

}
