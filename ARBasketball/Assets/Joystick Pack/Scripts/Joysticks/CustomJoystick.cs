using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CustomJoystick : Joystick
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        Debug.Log("Нажал на джойстик");
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        Debug.Log("Отпустил джойстик");
    }
}
