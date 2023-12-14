using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayPanel : MovePanel
{
    [SerializeField] private ItemMovement itemMovement;
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private Panel leftPanel;
    [SerializeField] private Panel rightPanel;
    public override void Initialize()
    {
        base.Initialize();

        leftPanel.Initialize();
        rightPanel.Initialize();
        ballSpawner.Initialize();
        itemMovement.Initialize();
    }

    public override void OpenPanel()
    {
        leftPanel.OpenPanel();
        base.OpenPanel();
    }

    public override void ClosePanel()
    {
        leftPanel.ClosePanel();
        rightPanel.ClosePanel();
        base.ClosePanel();
    }
}
