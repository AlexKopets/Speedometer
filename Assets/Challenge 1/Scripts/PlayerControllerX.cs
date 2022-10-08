﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private float speed = 15.0f;
    private float rotationSpeed = 50.0f;
    public float verticalInput;
    public float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward *verticalInput * Time.deltaTime * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
