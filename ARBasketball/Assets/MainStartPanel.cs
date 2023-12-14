using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStartPanel : Panel
{
    [SerializeField] private Panel leftMainPanel;
    [SerializeField] private Panel rightMainPanel;

    public override void Initialize()
    {
        base.Initialize();
        leftMainPanel.Initialize();
        rightMainPanel.Initialize();
    }

    public override void OpenPanel()
    {
        leftMainPanel.OpenPanel();
        rightMainPanel.OpenPanel();
    }

    public override void ClosePanel()
    {
        leftMainPanel.ClosePanel();
        rightMainPanel.ClosePanel();
    }
}
