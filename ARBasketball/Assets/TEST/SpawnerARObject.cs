using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerARObject : MonoBehaviour
{
    [SerializeField] private float MinMaxX;
    [SerializeField] private float MinMaxZ;
    [SerializeField] private Transform imageTarget;

    public void Spawn(GameObject objToSpawn)
    {
       GameObject obj = Instantiate(objToSpawn, imageTarget.transform.position + new Vector3(Random.Range(-MinMaxX, MinMaxX), 0.5f, Random.Range(-MinMaxZ, MinMaxZ)), Quaternion.identity);
        obj.transform.parent = imageTarget.parent;
    }
}
