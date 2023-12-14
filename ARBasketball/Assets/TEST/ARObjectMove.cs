using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectMove : MonoBehaviour
{
    [SerializeField] private ChangeColor changeColor;
    private Vector3 TouchPosition;
    private Camera ARCamera;
    private GameObject selectedObject;

    private void Awake()
    {
        ARCamera = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("Тестик");
            Touch touch = Input.GetTouch(0);
            TouchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Тест");
                Ray ray = ARCamera.ScreenPointToRay(TouchPosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Debug.Log("Тест");
                    if (hit.collider.gameObject.CompareTag("UnSelected"))
                    {
                        selectedObject = hit.collider.gameObject;
                        selectedObject.layer = LayerMask.NameToLayer("Selected");
                        selectedObject.tag = "Selected";

                        changeColor.ActivateUIPanel(true);
                        changeColor.SetARObject(selectedObject);
                    }
                }
            }

            if (touch.phase == TouchPhase.Moved)
            {
                Ray ray = ARCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, LayerMask.NameToLayer("Ray")))
                {
                    if (hit.collider.gameObject.CompareTag("Plane"))
                    {
                        selectedObject.transform.position = new Vector3(hit.point.x, selectedObject.transform.position.y, hit.point.z);
                    }
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                selectedObject.tag = "UnSelected";
                selectedObject.layer = LayerMask.NameToLayer("UnSelected");
                selectedObject = null;
            }

        }
    }
}
