using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class GameInventoryCell : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _nameField;
    [SerializeField] protected Image _iconField;

    protected Item _item;
    protected Button _button;
    protected IGameItem _gameItem;
    protected ItemSpawner itemSpawner;
    protected virtual void Awake()
    {
        _button = gameObject.GetComponent<Button>();
        _button.onClick.AddListener(Select);
    }

    public virtual void StartGame(IGameItem gameItem, ItemSpawner itemSpawner)
    {
        this.itemSpawner = itemSpawner;
        _gameItem = gameItem;
        _item = _gameItem.Item;

        VisibleData(_gameItem);
    }

    protected virtual void VisibleData(IGameItem gameItem)
    {
        _nameField.text = gameItem.Name;
        _iconField.sprite = gameItem.UIIcon;
    }

    protected virtual void Select()
    {
        itemSpawner.SetTypeItem(_item);
    }
}
