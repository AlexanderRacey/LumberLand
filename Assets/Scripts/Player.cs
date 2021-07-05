using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Requires usage of Controller2D script
[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    // Reference to controller
    Controller2D controller;

    void Start()
    {
        controller = GetComponent<Controller2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
