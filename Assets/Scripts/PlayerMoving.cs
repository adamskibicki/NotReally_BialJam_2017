using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    const float objectSize = 4f;
    Rigidbody2D body;
    PlayersSpeed speed;
    PlayersObserver observer;

    private void Start()
    {
        observer = transform.parent.GetComponent<PlayersObserver>();
        body = GetComponent<Rigidbody2D>();
        speed = transform.parent.GetComponent<PlayersSpeed>();
        transform.Rotate(new Vector3(0,0, FindObjectOfType<GameManager>().CurrentZValue));
        SnapToGrid();
    }

    private void Update()
    {
        ExecuteMove();
    }

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
        return transform.up * observer.vertical * 20f;
    }

    private void Turn()
    {
        float validTransform = 0;

        if (observer.left)
            validTransform = -objectSize;
        if (observer.right)
            validTransform = objectSize;

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

    }
}
