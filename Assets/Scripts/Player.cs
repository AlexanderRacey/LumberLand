using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requires usage of Controller2D script
[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    float moveSpeed = 6.0f;
    float gravity = -20.0f;
    Vector3 velocity;

    Controller2D controller;

    void Start()
    {
        controller = GetComponent<Controller2D>();
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        velocity.x = input.x * moveSpeed;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
