using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVolleyball : Item
{
    private Rigidbody rb;

    public override void Initialize()
    {
        base.Initialize();
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioInteractor.PlayOtherSound(source, "HitBall", rb.velocity.magnitude / 3, 0.8f);
    }
}
