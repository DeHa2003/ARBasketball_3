using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemsInventory : GameInventory
{
    public override void RenderInventory(List<AssetItem> items, ItemSpawner itemSpawner)
    {
        foreach (Transform child in _conterntContainer)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < items.Count; i++)
        {
            for (int q = 0; q < shopInteractor.IDsARItems.Count; q++)
            {
                if (items[i].ID == shopInteractor.IDsARItems[q])
                {
                    AddItem(items[i], itemSpawner);
                }
            }
        }
    }
}
