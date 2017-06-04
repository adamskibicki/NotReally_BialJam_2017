using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillTrigger : MonoBehaviour
{

    Animator animator;
    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    internal void ExecuteKillAnimation()
    {
        animator.SetTrigger("Attack");
    }
}
