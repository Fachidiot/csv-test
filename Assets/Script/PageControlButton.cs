using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PageControlButton : MonoBehaviour, IPointerClickHandler
{
    public TextScript PageControlText;
    public bool Next;
    public bool Prev;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Next)
        {
            PageControlText.IndexUp();
        }
        else if(Prev)
        {
            PageControlText.IndexDown();
        }
    }
}
