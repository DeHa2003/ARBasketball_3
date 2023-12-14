using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameInventory : MonoBehaviour
{
    [SerializeField] protected ItemSpawner itemSpawner;
    [SerializeField] protected List<AssetItem> _allItems;
    [SerializeField] protected GameInventoryCell _inventoryCell;
    [SerializeField] protected Transform _conterntContainer;

    protected ShopInteractor shopInteractor;
    public virtual void Initialize()
    {
        shopInteractor = Game.GetInteractor<ShopInteractor>();
        RenderInventory(_allItems, itemSpawner);
    }

    public virtual void RenderInventory(List<AssetItem> items, ItemSpawner itemSpawner)
    {
        
    }

    public void AddItem(AssetItem assetItem, ItemSpawner itemSpawner)
    {
        var cell = Instantiate(_inventoryCell, _conterntContainer);
        cell.StartGame(assetItem, itemSpawner);
    }
}
