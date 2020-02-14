using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{    

    public void OnPointerClick(PointerEventData eventData)
    {
        FindObjectOfType<AudioManager>().Play("StoryButtonClick");
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        FindObjectOfType<AudioManager>().Play("StoryButtonHover");
    }
}
