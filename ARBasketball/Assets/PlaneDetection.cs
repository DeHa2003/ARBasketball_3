using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneDetection : MonoBehaviour
{
    public static Action OnFoundZeroPosition;
    public static Action OnFoundPlanes;
    public Vector3 ZeroPosition { get; private set; }

    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private GameObject marker;
    private bool isActiveDetection = true;
    private void Awake()
    {
        marker.SetActive(false);
    }
    void Update()
    {
        ShowMarker();
    }

    private void ShowMarker()
    {
        if (isActiveDetection)
        {
            List<ARRaycastHit> raycastHits = new();
            raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), raycastHits, TrackableType.Planes);

            if (raycastHits.Count > 0)
            {
                OnFoundPlanes?.Invoke();
                marker.SetActive(true);
                marker.transform.position = raycastHits[0].pose.position;

                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                {
                    isActiveDetection = false;
                    OnFoundZeroPositionToSpawn();
                }
            }
        }
    }

    public void _ON_FOUND_PLACE_()
    {
        OnFoundPlanes?.Invoke();
    }

    public void _ON_POSITION_TO_SPAWN_()
    {
        OnFoundZeroPosition?.Invoke();
    }

    public void OnFoundZeroPositionToSpawn()
    {
        OnFoundZeroPosition?.Invoke();
        ZeroPosition = marker.transform.position;
        gameObject.GetComponent<PlaneDetection>().enabled = false;
    }
}
