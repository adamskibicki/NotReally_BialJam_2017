using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    Action OnPlayerInteraction;
    Animator animator;

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        OnPlayerInteraction += FindObjectOfType<CoinsManager>().CoinAchieved;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerKillTrigger>().ExecuteKillAnimation();

            if (OnPlayerInteraction != null)
                OnPlayerInteraction();
            GotKilledAnimation();


        
        }
    }

    private void GotKilledAnimation()
    {
        animator.SetTrigger("Dead");
        StartCoroutine(WaitThenDie());
    }

    private IEnumerator WaitThenDie()
    {
        yield return new WaitForSeconds(1.5f);
    }

    public void AddOnTriggerAction(Action x)
    {
        OnPlayerInteraction += x;
    }
}
