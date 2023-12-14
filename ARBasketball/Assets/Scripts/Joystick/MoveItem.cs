using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveItem : JoystickScript
{
    private void Update()
    {
        if (rb == null) { Debug.Log("Предмет не выбран"); return; }

        rb.velocity = new Vector3(-joystick.Horizontal * speed, rb.velocity.y, -joystick.Vertical * speed);
    }
}
