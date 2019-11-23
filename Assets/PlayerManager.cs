using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    //Variables used in top panel
    public Button profileButton;
    public Button evaluationButton;
    public GameObject profilePanel;
    public GameObject evaluationPanel;
    public GameObject playerCanvas;

    //Variables used for the evaluation
    public GameObject content;
    public Button[] scenarioButtons;
    public GameObject[] selectionPanel;
    
    public void OnClickProfile()
    {
        profileButton.GetComponent<Image>().color = Color.red;
        evaluationButton.GetComponent<Image>().color = Color.white;

        profilePanel.SetActive(true);
        evaluationPanel.SetActive(false);
    }

    //While clicking the evaluation button need to display the evaluation of level 1 of scenario 1 under resultsPanel
    public void OnCLickEvaluation()
    {
        profileButton.GetComponent<Image>().color = Color.white;
        evaluationButton.GetComponent<Image>().color = Color.red;

        profilePanel.SetActive(false);
        evaluationPanel.SetActive(true);

        playerCanvas.GetComponent<PlayerManager>().ColorChange(0);
    }

    //Change the colour of the selected button in scenario and to display the evaluation of level 1 in each scenario. 
    public void ColorChange(int id)
    {        
        for (int i = 0; i < scenarioButtons.Length; i++)
        {
            if (i == id)
            {                
                scenarioButtons[i].GetComponent<Image>().color = Color.red;
                selectionPanel[i].SetActive(true);
                selectionPanel[i].GetComponent<EvaluationDisplay>().ColorChange(0);
            }
            else
            {
                scenarioButtons[i].GetComponent<Image>().color = Color.white;
                selectionPanel[i].SetActive(false);
            }
        }
    }
    
    /* When clicking the logout button need to delete the player credentials which were save locally while logging in. 
     * Then navigate to the login scene.  */
    public void DeletePlayerData()
    {
        string path = Application.persistentDataPath + "/player.vita";
        if (File.Exists(path))
        {
            File.Delete(path);
            DBManager.LogOut();
            //SceneManager.LoadScene(0);
            StartCoroutine(LoadLogin());
        }
        else
        {
            Debug.Log("File not found in path " + path);
        }       
    }

    IEnumerator LoadLogin()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }
}
