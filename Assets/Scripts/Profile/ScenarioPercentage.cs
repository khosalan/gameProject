using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioPercentage : MonoBehaviour
{
    public int scenarioID;

    public Text progressText;
    public Slider slider;

    [System.Obsolete]
    void Start()
    {
        StartCoroutine(DisplayPercentage());
    }

    [System.Obsolete]
    IEnumerator DisplayPercentage()
    {
        WWWForm form = new WWWForm();
        int playerID = DBManager.playerID;

        form.AddField("playerID", playerID);
        form.AddField("scenarioID", scenarioID);

        WWW www = new WWW("http://localhost/gameProjSample/percentageScenario.php", form);
        yield return www;

        if (www.text[0] == '0')
        {
            string percentage = www.text.Split('\t')[1];
            progressText.text = percentage + "%";
            float.TryParse(percentage, out float result);
            slider.GetComponent<Slider>().value = result;
        }
    }
}
