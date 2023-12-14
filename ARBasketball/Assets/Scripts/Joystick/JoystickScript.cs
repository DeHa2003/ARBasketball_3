using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickScript : MonoBehaviour
{
    protected ItemSpawner spawner;
    protected Joystick joystick;
    protected float speed;
    protected Transform itemBody;
    protected Rigidbody rb;
    protected Item item;
    public virtual void SetData(ItemSpawner itemSpawner, Joystick joystick, float speed)
    {
        
        this.spawner = itemSpawner;
        this.joystick = joystick;
        this.speed = speed;

        item = spawner._spawningObj;
        if(item == null) { return; }
        itemBody = item.gameObject.transform;
        rb = item.gameObject.AddComponent<Rigidbody>();
        rb = item.gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = false;
    }

    public virtual void RemoveData()
    {
        Destroy(item.GetComponent<Rigidbody>());
        item = null;
    }
}
