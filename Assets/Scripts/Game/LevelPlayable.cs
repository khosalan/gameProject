using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPlayable : MonoBehaviour
{    
    public int level;

    public GameObject levelCanvas;
    public GameObject locked;
    public GameObject levelText;
    public GameObject loadingPanel;
    public GameObject alertPanel;

    private bool isUpdated = false;

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(!isUpdated)
        {
            loadingPanel.SetActive(true);            
            StartCoroutine(CheckPlayable());
            isUpdated = true;
        }
    }

    [System.Obsolete]
    IEnumerator CheckPlayable()
    {
        WWWForm form = new WWWForm();
        form.AddField("playerID", DBManager.playerID);
        form.AddField("scenarioID", levelCanvas.GetComponent<BackToMenu>().scenarioID);
        form.AddField("levelID", level);

        WWW www = new WWW("http://localhost/gameProjSample/played.php", form);
        
        yield return www;

        if (www.error != null)
        {
            FindObjectOfType<AudioManager>().Play("Alertbox");
            alertPanel.SetActive(true);
        }
        else
        {
            if (www.text[0] == '1')
            {
                locked.SetActive(false);
                levelText.SetActive(true);
                gameObject.GetComponent<Button>().enabled = true;
            }
            loadingPanel.SetActive(false);

        }
        
    }

    public void OnClickRetry()
    {
        StartCoroutine(CheckPlayable());
        alertPanel.SetActive(false);
    }

    public void OnClickQuit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
		Application.Quit();
        #endif
    }
}
