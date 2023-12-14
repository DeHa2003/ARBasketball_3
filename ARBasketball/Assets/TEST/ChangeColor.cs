using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private GameObject UIPanel;
    private GameObject _ARObject;

    public void ActivateUIPanel(bool isActivate)
    {
        UIPanel.SetActive(isActivate);
    }
    public void SetARObject(GameObject ARObject)
    {
        _ARObject = ARObject;
    }

    public void ChangeMaterial(Material material)
    {
        _ARObject.GetComponent<MeshRenderer>().material = material;
    }
}
