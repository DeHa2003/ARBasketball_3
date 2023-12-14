using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMenuItem
{
    int ID { get; }
    string Name { get; }
    int price { get; }
    string description { get; }
    Sprite UIIcon { get; }
    TypeItem TypeItem { get; }


}

public enum TypeItem
{
    Item, Target
}
