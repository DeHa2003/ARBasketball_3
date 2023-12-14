using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTargetsInventory : GameInventory
{
    public override void RenderInventory(List<AssetItem> items, ItemSpawner itemSpawner)
    {
        foreach (Transform child in _conterntContainer)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < items.Count; i++)
        {
            for (int q = 0; q < shopInteractor.IDsARTargets.Count; q++)
            {
                if (items[i].ID == shopInteractor.IDsARTargets[q])
                {
                    AddItem(items[i], itemSpawner);
                }
            }
        }
    }
}
