﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    const float objectSize = 4f;
    float vertical;
    Rigidbody2D body;
    PlayersSpeed speed;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        speed = transform.parent.GetComponent<PlayersSpeed>();
        transform.Rotate(new Vector3(0,0, FindObjectOfType<GameManager>().currentZValue));
        SnapToGrid();
    }

    void Update()
    {
        GetAxis();
    }

    private void FixedUpdate()
    {
        ExecuteMove();
    }

    private bool left, right;

    private void ExecuteMove()
    {
        Turn();
        body.velocity = BoostFromController() +
            BoostFromConstantMove();
    }

    private Vector3 BoostFromConstantMove()
    {
        return transform.up * speed.GetPlayerSpeed();
    }

    private Vector3 BoostFromController()
    {
        return transform.up * vertical * 20f;
    }

    private void Turn()
    {
        float validTransform = 0;

        if (left)
            validTransform = -objectSize;
        if (right)
            validTransform = objectSize;

        left = right = false;

        transform.localPosition += transform.right * validTransform;
    }

    public void SnapToGrid()
    {
        float xPos = Mathf.RoundToInt(transform.position.x/objectSize)* objectSize;
        float yPos = Mathf.RoundToInt(transform.position.y/objectSize)* objectSize;
        transform.position = new Vector3(xPos, yPos, 0f);
    }

    private void GetAxis()
    {
        //left = Input.GetButtonDown("LeftMove");
        //right = Input.GetButtonDown("RightMove");
        left = Input.GetKeyDown(KeyCode.A);
        right = Input.GetKeyDown(KeyCode.D);
        vertical = Input.GetAxis("Vertical");
    }
}
