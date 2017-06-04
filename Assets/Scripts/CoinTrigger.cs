using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTrigger : MonoBehaviour
{
    Action OnPlayerInteraction;

    private void Start()
    {
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
        Destroy(gameObject);
        //throw new NotImplementedException();
        
    }

    public void AddOnTriggerAction(Action x)
    {
        OnPlayerInteraction += x;
    }
}
