using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceARTargetPanel : Panel
{
    [SerializeField] private GameTargetsInventory targetsInventory;
    [SerializeField] private ItemSpawner itemSpawner;

    private NotificationInteractor notificationInteractor;
    public override void Initialize()
    {
        base.Initialize();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();
        targetsInventory.Initialize();
    }

    public void CheckspawningObject()
    {
        if(itemSpawner.SpawningObj == null)
        {
            notificationInteractor.CreateNotification("Warning", "Not selected AR target");
        }
    }
}
