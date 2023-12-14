using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScenePanelsControl : PanelsControl
{
    [SerializeField] private Panel searchPanel;
    [SerializeField] private Panel choicePlacePanel;
    [SerializeField] private Panel choiceARTargetPanel;
    [SerializeField] private Panel gameplayPanel;
    [SerializeField] private Panel moveRotatePanel;

    public override void Initialize()
    {
        base.Initialize();

        PlaneDetection.OnFoundPlanes += OnFoundPlanes;
        PlaneDetection.OnFoundZeroPosition += OnFoundZeroPos;

        transitionPanel.Initialize();
        choicePlacePanel.Initialize();
        searchPanel.Initialize();
        choiceARTargetPanel.Initialize();
        gameplayPanel.Initialize();
        moveRotatePanel.Initialize();
        OpenPanel(searchPanel);
    }

    private void OnFoundPlanes()
    {
        OpenPanel(choicePlacePanel);
        PlaneDetection.OnFoundPlanes -= OnFoundPlanes;
    }
    private void OnFoundZeroPos()
    {
        OpenPanel(choiceARTargetPanel);
        PlaneDetection.OnFoundZeroPosition -= OnFoundZeroPos;
    }
}
