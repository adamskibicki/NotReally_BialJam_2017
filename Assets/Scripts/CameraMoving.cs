﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{

    [SerializeField]
    float speed = 20f;

    Vector3 moveVector;

    private void Start()
    {
        moveVector = transform.up;
    }

    private void Update()
    {
        transform.Translate(moveVector * speed * Time.deltaTime);
        speed += Time.deltaTime * 2f;
    }

    internal void MoveDirection(Vector3 turnVector)
    {
        int z = Mathf.RoundToInt(turnVector.z);
        z %= 360;
        switch (z)
        {
            case 0:
                moveVector =transform.up;
                break;
            case 90:
                moveVector = -transform.right;

                break;
            case 180:
                moveVector = -transform.up;

                break;
            case 270:
                moveVector = transform.right;

                break;
            default:
                Debug.LogError("ZLY INT ROTACJI");
                break;
        }

    }
}
