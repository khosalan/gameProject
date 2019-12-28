using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageZoom : MonoBehaviour
{    

    public void OnMouseEnter(Image image)
    {
        image.rectTransform.localScale = new Vector3(2,2);        
    }

    public void OnMouseExit(Image image)
    {
        image.rectTransform.localScale = new Vector3(1, 1);        
    }

    public void ShowText(GameObject text)
    {
        text.SetActive(true);
    }

    public void HideText(GameObject text)
    {
        text.SetActive(false);
    }
}
