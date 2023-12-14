using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class AssetItem : ScriptableObject, IGameItem
{
    public int ID => _id;
    public string Name => _name;

    public Sprite UIIcon => _icon;

    public Item Item => _item;

    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Item _item;
}
