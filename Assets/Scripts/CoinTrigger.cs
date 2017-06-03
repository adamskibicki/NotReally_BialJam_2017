using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    Action OnPlayerInteraction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerKillTrigger>().ExecuteKillAnimation();
            GotKilledAnimation();

            if (OnPlayerInteraction != null)
                OnPlayerInteraction();
        }
    }

    private void GotKilledAnimation()
    {
        throw new NotImplementedException();
    }

    public void AddOnTriggerAction(Action x)
    {
        OnPlayerInteraction += x;
    }
}
