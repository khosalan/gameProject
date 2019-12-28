using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour
{
    public void OnClickUniversity()
    {
        SceneManager.LoadScene(3);
    }
}
