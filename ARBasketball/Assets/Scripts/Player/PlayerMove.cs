using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float gravity;
    [SerializeField] private float moveSpeed;

    private Vector3 moveVectorDirection;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        moveVectorDirection.y -= gravity * Time.deltaTime;

        if (controller.isGrounded)
        {
            moveVectorDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveVectorDirection = transform.TransformDirection(moveVectorDirection) * moveSpeed;
        }
    }
}
