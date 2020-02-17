using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class InkStoryManager : MonoBehaviour
{
    [SerializeField]
    public TextAsset inkJsonText;

    public DialogView dialogView;

    private Story story;
    //Holds the tags in ink file 
    private Dictionary<string, System.Action<string>> tagProcessors = new Dictionary<string, System.Action<string>>();

    public UnityEngine.Events.UnityAction storyEndAction = delegate { };

    public int operation;
    public int currentLevel;
    public int nextLevel;

    public string remarks = "";

    public GameObject levelCanvas;
    public GameObject pauseButton;
    public GameObject saveCanvas;
    public GameObject alertCanvas;

    public void StartStory()
    {
        story = new Story(inkJsonText.text);
        ContinueStory();
    }

    public void ContinueStory()
    {
        dialogView.ClearPanel();    //First removes all the child objects in DialogPanel, means all the previous StoryText and ChoiceButton    
        string text = story.Continue().Trim();
        dialogView.SetStoryText(text);      //Set the text for StoryText  

        //If the choice exist for the current story 
        if (story.currentChoices.Count > 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                Choice choice = story.currentChoices[i];
                dialogView.AddChoice(choice.text.Trim(), delegate {
                    Continue(choice.index);
                });
            }
        }
        else if (IsEnded())
        {
            pauseButton.SetActive(false);
            saveCanvas.SetActive(true);
            ProcessTags(story.currentTags);
            StartCoroutine(GoRemarks(remarks));
        }
        else
        {
            dialogView.AddChoice("CONTINUE", delegate {
                ContinueStory();
            }, TextAnchor.LowerRight);
        }
        ProcessTags(story.currentTags);
        dialogView.DisplayPanel();
    }


    IEnumerator GoRemarks(string text)
    {
        WWWForm form = new WWWForm();

        form.AddField("playerID", DBManager.playerID);
        form.AddField("operation", operation);
        form.AddField("currentScenario", levelCanvas.GetComponent<BackToMenu>().scenarioID);
        form.AddField("currentLevel", currentLevel);
        form.AddField("currentRemark", text);
        form.AddField("nextLevel", nextLevel);

        WWW www = new WWW("http://localhost/gameProjSample/evaluation.php", form);
        yield return www;
        /*if (www.text[0] == '0')
        {
            Debug.Log(www.text.Split('\t')[1]);
        }
        else
            Debug.Log("else");*/
        if (www.error != null)
        {
            Debug.Log("Connection Error");
            FindObjectOfType<AudioManager>().Play("Alertbox");
            alertCanvas.SetActive(true);
            alertCanvas.GetComponent<AlertMessage>().remarks = text;
        }
        else
        {
            saveCanvas.SetActive(false);
            dialogView.AddChoice("END", storyEndAction, TextAnchor.LowerRight);
        }

    }

    public void Continue(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    public bool IsEnded()
    {
        return this.story.currentChoices.Count == 0 && !this.story.canContinue;
    }

    public void AddTagProcessor(string tag, System.Action<string> onTag)
    {
        tagProcessors.Add(tag, onTag);
    }

    public void ProcessTags(List<string> tags)
    {
        if (tags == null) return;
        System.Action<string> processor;
        foreach (string tag in tags)
        {
            Debug.Log(tag);
            string keyOfTag = tag.Split(':')[0];
            if (tagProcessors.TryGetValue(keyOfTag, out processor))
            {
                string valueOfTag = tag.Split(':')[1];
                processor.Invoke(valueOfTag);
            }
        }
    }

    public void OnClickRetry()
    {
        StartCoroutine(GoRemarks(alertCanvas.GetComponent<AlertMessage>().remarks));
        alertCanvas.SetActive(false);
        saveCanvas.SetActive(true);
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
