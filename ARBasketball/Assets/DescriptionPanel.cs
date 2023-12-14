using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DescriptionPanel : MonoBehaviour
{
    public UnityEvent OnBuyItem;

    [SerializeField] private GameObject button;
    [SerializeField] private Image imageItem;
    [SerializeField] private TextMeshProUGUI nameItem;
    [SerializeField] private TextMeshProUGUI descriptionItem;
    [SerializeField] private TextMeshProUGUI priceText;

    private AudioInteractor audioInteractor;
    private ShopInteractor shopInteractor;
    private BankInteractor bankInteractor;
    private NotificationInteractor notificationInteractor;
    private IMenuItem menuItem;

    public void Initialize()
    {
        audioInteractor = Game.GetInteractor<AudioInteractor>();
        shopInteractor = Game.GetInteractor<ShopInteractor>();
        bankInteractor = Game.GetInteractor<BankInteractor>();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();
    }
    public void SetData(IMenuItem menuItem)
    { 
        if(gameObject.activeSelf == false) { gameObject.SetActive(true); }
        this.menuItem = menuItem;
        button.SetActive(true);
        VisibleData(this.menuItem);
        Check(this.menuItem);
    }

    private void VisibleData(IMenuItem menuItem)
    {
        imageItem.sprite = menuItem.UIIcon;
        nameItem.text = menuItem.Name;
        descriptionItem.text = menuItem.description;
        priceText.text = menuItem.price.ToString();
    }

    private void Check(IMenuItem menuItem)
    {
        switch (menuItem.TypeItem)
        {
            case TypeItem.Item:
                CheckList(shopInteractor.IDsARItems);
                break;
            case TypeItem.Target:
                CheckList(shopInteractor.IDsARTargets);
                break;

        }
    }

    private void CheckList(List<int> IDs)
    {
        for (int i = 0; i < IDs.Count; i++)
        {
            
            if (menuItem.ID == IDs[i])
            {
                OffBuy();
                break;
            }
        }
    }

    private void OffBuy()
    {
        priceText.text = null;
        button.SetActive(false);
    }

    public void BuyItem()
    {
        if(bankInteractor.Coins < menuItem.price) 
        {
            notificationInteractor.CreateNotification("Error", "Don't have enough " + "<color=#FF3333>" + (menuItem.price - bankInteractor.Coins).ToString() + "</color> coins");
            audioInteractor.PlayEffectSound("Error");
            return;
        }

        switch (menuItem.TypeItem)
        {
            case TypeItem.Item:
                bankInteractor.Spend(this, menuItem.price);
                shopInteractor.BuyARItem(this, menuItem.ID);
                break;
            case TypeItem.Target:
                bankInteractor.Spend(this, menuItem.price);
                shopInteractor.BuyARTarget(this, menuItem.ID);
                break;
        }

        OnBuyItem?.Invoke();
        notificationInteractor.CreateNotification("Message", "A <color=#FF3333>" + menuItem.Name + "</color> has been purchased and added to your inventory");
        audioInteractor.PlayEffectSound("Buy");
        OffBuy();
    }
}
