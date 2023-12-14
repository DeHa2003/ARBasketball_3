using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SingleInventory
{
    [SerializeField] private string name;
    [SerializeField] private List<MenuItem> ARItems;
    [SerializeField] private Transform parentToARItems;

    public List<MenuItem> GetItems()
    {
        return ARItems;
    }

    public Transform GetParent()
    {
        return parentToARItems;
    }
}

public class MenuInventory : MonoBehaviour
{
    [SerializeField] private DescriptionPanel descriptionPanel;
    [SerializeField] private MenuInventoryCell menuInventoryCellPref;
    [SerializeField] private List<SingleInventory> singleInventories;
    public void Initialize()
    {
        descriptionPanel.Initialize();
        RenderInventory(singleInventories[0].GetItems(), singleInventories[0].GetParent());
        RenderInventory(singleInventories[1].GetItems(), singleInventories[1].GetParent());
    }

    public void RenderInventory(List<MenuItem> items, Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < items.Count; i++)
        {
            
            AddItem(items[i], parent);
        }
    }

    public void AddItem(MenuItem menuItem, Transform parent)
    {
        var cell = Instantiate(menuInventoryCellPref, parent);
        cell.SetData(menuItem, descriptionPanel);
    }
}
