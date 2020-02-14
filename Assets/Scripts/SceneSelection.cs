using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSelection : MonoBehaviour
{
    public GameObject loadPanel;
    public Slider slider;
    public Text progreeText;
    public void OnClickScenario(int sceneIndex)
    {
        loadPanel.SetActive(true);
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);        

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progreeText.text = Mathf.RoundToInt(progress * 100f) + "%";
            Debug.Log(progress);
            yield return null;

        }
    }

    
}
