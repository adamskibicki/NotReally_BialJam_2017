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
        throw new NotImplementedException();
    }

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        body.velocity = (transform.up * speed * Time.deltaTime);
        speed += Time.deltaTime*2f;
    }

}

