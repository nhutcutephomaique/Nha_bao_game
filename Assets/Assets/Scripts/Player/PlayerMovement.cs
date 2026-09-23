using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float runSpeed = 18f;
    public float gravity = -9.81f * 2;

    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;

        Vector3 move = transform.right * x + transform.forward * z;
        if (move.magnitude > 1f)
        {
            move.Normalize();
        }

        controller.Move(move * currentSpeed * Time.deltaTime);

        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
