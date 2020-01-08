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
    private bool isUpdated = false;

    // Update is called once per frame
    void Update()
    {
        if(!isUpdated)
        {
            StartCoroutine(CheckPlayable());
            isUpdated = true;
        }
    }

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
            gameObject.GetComponent<Button>().interactable = true; //not working, resolve the button click

        }
    }
}
