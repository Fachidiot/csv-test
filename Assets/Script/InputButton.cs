using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputButton : MonoBehaviour, IPointerClickHandler
{
    public InputField input;
    public TextScript FindName;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        FindName.FindName(input.text.ToString());
    }
}
