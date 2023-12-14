using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSpawner : ItemSpawner
{
    [SerializeField] private Slider slider;
    [SerializeField] private ItemMovement itemMovement;

    private AudioInteractor audioInteractor;
    private NotificationInteractor notificationInteractor;
    public void Initialize()
    {
        audioInteractor = Game.GetInteractor<AudioInteractor>();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();
    }

    private void OnEnable()
    {
        SliderHandle.OnPointerSliderUp += Fire;
    }

    private void OnDisable()
    {
        SliderHandle.OnPointerSliderUp -= Fire;
    }

    public void Fire()
    {
        if(typeItem == null)
        {
            notificationInteractor.CreateNotification("Warning", "Not selected item");
            audioInteractor.PlayEffectSound("Error");
        }

        if (_spawningObj == null) 
        {
            Debug.Log("Нет предмета");
            return; 
        }

        itemMovement.MoveItem(_spawningObj);

        DiactivateItem();
        Invoke(nameof(SpawnItem), 0.5f);

    }

    private void DiactivateItem()
    {
        _spawningObj.Invoke(nameof(_spawningObj.UnvisibleItem), 1.7f);
        _spawningObj = null;

    }
}
