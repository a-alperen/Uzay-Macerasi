using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickButon : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    [HideInInspector]
    public bool tusaBasildi;

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        
        tusaBasildi = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        tusaBasildi = false;
    }
}
