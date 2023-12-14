using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderHandle : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public static event Action OnPointerSliderUp;
    [SerializeField] private Slider slider;
    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnPointerSliderUp?.Invoke();

        Debug.Log(slider.value);
        slider.value = slider.minValue;
    }
}
