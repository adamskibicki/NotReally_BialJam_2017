using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    const float objectSize = 4f;
    float vertical;
    Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetAxis();
        ExecuteMove();
    }
    private bool left, right;

    private void ExecuteMove()
    {
        float validTransform = 0;

        if (left)
            validTransform = -objectSize;
        if (right)
            validTransform = objectSize;

        transform.localPosition += transform.right * validTransform;
        body.velocity = transform.up * vertical * 20f;
    }

    private void GetAxis()
    {
        left = Input.GetButtonDown("LeftMove");
        right = Input.GetButtonDown("RightMove");
        vertical = Input.GetAxis("Vertical");
    }

}
