using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requires usage of Controller2D script
[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public float jumpHeight = 4;
    public float timeToJumpApex = 0.4f;

    float accelerationTimeAirborne = 0.2f;
    float accelerationTimeGrounded = 0.1f;
    float moveSpeed = 6;

    float gravity;
    float jumpVelocity;
    float velocityXSmoothing;

    Vector3 velocity;

    Controller2D controller;

    void Start()
    {
        controller = GetComponent<Controller2D>();

        // Calculate values
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
    }

    void Update()
    {
        // Prevent player accumulating gravity
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Allow jump if player is touching floor
        if (Input.GetKeyDown(KeyCode.Space) && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
        }

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded:accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
