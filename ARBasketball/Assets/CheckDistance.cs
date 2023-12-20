using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDistance : MonoBehaviour
{
    [SerializeField] private GameObject slider;
    [SerializeField] private ItemSpawner ARSpawner;
    [SerializeField] private ItemSpawner ballSpawner;
    [SerializeField] private float minDistance;

    private float distance;
    private bool isActiveGame = true;
    void Update()
    {
        if(ARSpawner.SpawningObj == null || ballSpawner.SpawningObj == null) { return; }

        distance = Vector3.Distance(ARSpawner.SpawningObj.transform.position, ballSpawner.SpawningObj.transform.position);

        if (distance < minDistance)
        {
            if (isActiveGame)
            {
                isActiveGame = false;
                ballSpawner.SpawningObj.gameObject.SetActive(false);
                slider.SetActive(false);
                Debug.Log("Отключено");
            }
        }
        else
        {
            if (!isActiveGame)
            {
                isActiveGame = true;
                ballSpawner.SpawningObj.gameObject.SetActive(true);
                slider.SetActive(true);
                Debug.Log("Включено");
            }
        }
    }
}
