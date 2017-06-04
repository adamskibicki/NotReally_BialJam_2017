using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour, IResetGame
{
    public void OnResetGame()
    {
        Rotate(0);
    }

    public void Rotate(float rotationValue)
    {
        transform.eulerAngles = new Vector3(0, 0, rotationValue);
    }
}
