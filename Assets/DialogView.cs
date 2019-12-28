using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogView : MonoBehaviour
{
    [SerializeField]
    private Text storyTextPrefab;

    [SerializeField]
    private Button choicePrefab;

    public GameObject mainPanel;

    public void ClearPanel()
    {
        int childCount = mainPanel.transform.childCount;
        for(int i = 0; i < childCount; i++)
        {
            GameObject.Destroy(mainPanel.transform.GetChild(i).gameObject);
        }
        mainPanel.SetActive(false);
    }

    public void DisplayPanel()
    {
        mainPanel.SetActive(true);
    }

    public void SetStoryText(string text)
    {
        Text storyText = Instantiate(storyTextPrefab) as Text;
        storyText.text = text;
        storyText.transform.SetParent(mainPanel.transform, false);
    }

    public void AddChoice(string text, UnityEngine.Events.UnityAction onClick, TextAnchor alignment = TextAnchor.UpperCenter)
    {
        Button choice = Instantiate(choicePrefab) as Button;
        choice.transform.SetParent(mainPanel.transform, false);
        choice.onClick.AddListener(onClick);

        Text choiceText = choice.GetComponentInChildren<Text>();
        choiceText.text = text;
        choiceText.alignment = alignment;
        
    }
}
