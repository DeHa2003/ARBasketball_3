using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    [SerializeField] private string path;

    public void OpenUrl()
    {
        Application.OpenURL(path);
    }


}
