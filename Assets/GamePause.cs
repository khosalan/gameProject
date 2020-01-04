using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public void OnClickPauseButton()
    {
        gameObject.SetActive(true);
    }
}
