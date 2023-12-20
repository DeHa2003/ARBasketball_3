using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Item SpawningObj { get; set; }

    [SerializeField] protected Transform posToSpawn;

    protected Item typeItem;


    public virtual void SetTypeItem(Item item)
    {
        typeItem = item;

        if (SpawningObj != null)
        {
            if (SpawningObj.GetType() == item.GetType())
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
        if (typeItem != null && SpawningObj == null)
        {
            SpawningObj = Instantiate(typeItem, posToSpawn.position, Quaternion.identity);
            SpawningObj.Initialize();
            SpawningObj.VisibleItem();
            SpawningObj.transform.parent = posToSpawn.parent;
        }
    }

    public void DestroyItem()
    {
        SpawningObj.UnvisibleItem();
        SpawningObj = null;
    }
}
