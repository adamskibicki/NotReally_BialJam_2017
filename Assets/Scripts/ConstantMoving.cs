using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMoving : MonoBehaviour, IMovingSpeed
{
    [SerializeField]
    float speed = 20f;

    Rigidbody2D body;

    public float SpeedBoost()
    {
        return speed;
    }

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        speed += Time.deltaTime*2f;
    }
}

