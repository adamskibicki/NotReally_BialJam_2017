using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour, IResetGame
{
    Animator animator;


    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        Rotate(FindObjectOfType<GameManager>().CurrentZValue);
    }

    public void OnResetGame()
    {
        Rotate(0);
    }

    public void Rotate(float rotationValue)
    {
        transform.eulerAngles = new Vector3(0, 0, rotationValue);

        int rotationDirection = Mathf.RoundToInt((rotationValue % 360) / 90f);
        switch (rotationDirection)
        {
            case 0:
                animator.SetTrigger("Up");
                break;
            case 1:
                animator.SetTrigger("Left"); 
                break;
            case 2:
                animator.SetTrigger("Down");
                break;
            case 3:
                animator.SetTrigger("Right");
                break;
        }
    }
}