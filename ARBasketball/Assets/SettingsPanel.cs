using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPanel : MovePanel
{
    [SerializeField] private Settings settings;
    public override void Initialize()
    {
        base.Initialize();
        settings.Initialize();
    }

    protected override void PlaySound()
    {
        audioInteractor.PlayEffectSound("OpenOther");
    }
}
