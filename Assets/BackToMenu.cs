using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public int scenarioID;
    public int currentScene;
    public void OnClickBack()
    {
        SceneManager.LoadScene(2);
    }
}
