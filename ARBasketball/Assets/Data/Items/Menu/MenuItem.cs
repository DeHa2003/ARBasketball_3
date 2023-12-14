using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MenuItem")]
public class MenuItem : ScriptableObject, IMenuItem
{
    public int ID => _id;
    public int price => _price;
    public string Name => _name;
    public Sprite UIIcon => _icon;
    public string description => _description;
    public TypeItem TypeItem => _type;

    [SerializeField] private int _id;
    [SerializeField] private int _price;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private string _description;
    [SerializeField] private TypeItem _type;
}
