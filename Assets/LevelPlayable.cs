using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPlayable : MonoBehaviour
{
    public int scenario;
    public int level;
    public GameObject locked;
    public GameObject levelText;
    public GameObject loadingPanel;

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
        form.AddField("scenarioID", scenario);
        form.AddField("levelID", level);

        WWW www = new WWW("http://localhost/gameProjSample/played.php", form);
        
        yield return www;
        if (www.text[0] == '1')
        {
            locked.SetActive(false);
            levelText.SetActive(true);
            gameObject.GetComponent<Button>().enabled = true;                   
        }
        loadingPanel.SetActive(false);
    }
}
