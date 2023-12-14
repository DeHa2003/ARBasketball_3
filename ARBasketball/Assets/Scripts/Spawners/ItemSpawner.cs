using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Item _spawningObj { get; set; }

    [SerializeField] protected Transform posToSpawn;

    protected Item typeItem;


    public virtual void SetTypeItem(Item item)
    {
        typeItem = item;

        if (_spawningObj != null)
        {
            if (_spawningObj.GetType() == item.GetType())
            {
                Debug.Log("Этот объект уже выбран");
                return;
            }
            DestroyItem();
            Debug.Log("Старый объект был удалён");
        }

        SpawnItem();
    }

    protected void SpawnItem()
    {
        if (typeItem != null && _spawningObj == null)
        {
            _spawningObj = Instantiate(typeItem, posToSpawn.position, Quaternion.identity);
            _spawningObj.Initialize();
            _spawningObj.VisibleItem();
            _spawningObj.transform.parent = posToSpawn.parent;
        }
    }

    public void DestroyItem()
    {
        _spawningObj.UnvisibleItem();
        _spawningObj = null;
    }
}
