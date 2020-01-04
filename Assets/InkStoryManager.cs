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
    private Dictionary<string, System.Action<string>> tagProcessors = new Dictionary<string, System.Action<string>>();

    public void StartStory()
    {
        story = new Story(inkJsonText.text);
        ContinueStory();
    }

    public void ContinueStory()
    {
        dialogView.ClearPanel();        
        string text = story.Continue().Trim();
        dialogView.SetStoryText(text);

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
        /*else if (isEnded())
        {
            dialogView.AddChoice("●", storyEndAction, TextAnchor.LowerRight);
        }*/
        else
        {
            dialogView.AddChoice("▼", delegate {
                ContinueStory();
            }, TextAnchor.LowerRight);
        }
        ProcessTags(story.currentTags);
        dialogView.DisplayPanel();
    }

    public void Continue(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
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
}
