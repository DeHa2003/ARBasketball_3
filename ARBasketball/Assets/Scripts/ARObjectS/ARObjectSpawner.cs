using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectSpawner : ItemSpawner
{ 
    public void SetPosition(Transform transform)
    {
        this.posToSpawn = transform;
    }
}
