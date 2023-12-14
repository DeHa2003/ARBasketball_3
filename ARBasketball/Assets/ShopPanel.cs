using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MovePanel
{
    [SerializeField] private MenuInventory menuInventory;
    [SerializeField] private Coins coins;
    public override void Initialize()
    {
        base.Initialize();
        menuInventory.Initialize();
        coins.Initialize();
    }

    protected override void PlaySound()
    {
        audioInteractor.PlayEffectSound("OpenOther");
    }
}
