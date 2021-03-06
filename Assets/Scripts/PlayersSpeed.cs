﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersSpeed : MonoBehaviour
{
    [SerializeField]
    float speed = 20f;

    private void Update()
    {
        speed += Time.deltaTime * 1.3f;
    }

    public float GetPlayerSpeed()
    {
        return speed;
    }
}
