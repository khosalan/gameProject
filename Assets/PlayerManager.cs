using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public GameObject content;
    public Button[] scenarioButtons;
    public GameObject[] selectionPanel;    

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
