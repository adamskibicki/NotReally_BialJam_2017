using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathCondition : MonoBehaviour {

    public void Kill()
    {

        Destroy(gameObject);
    }
}
