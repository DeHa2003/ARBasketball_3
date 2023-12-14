using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuInventoryCell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image icon;
    private Button button;

    private DescriptionPanel descriptionPanel;
    private IMenuItem menuItem;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Select);
    }

    public void SetData(IMenuItem menuItem, DescriptionPanel descriptionPanel)
    {
        this.descriptionPanel = descriptionPanel;
        this.menuItem = menuItem;

        nameText.text = menuItem.Name;
        icon.sprite = menuItem.UIIcon;

    }

    private void Select()
    {
        descriptionPanel.SetData(menuItem);
    }
}
