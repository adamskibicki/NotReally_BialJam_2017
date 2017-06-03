using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LethalObjectCollision : MonoBehaviour {

    // Use this for initialization
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Kolizja z " + collision.gameObject.name);
        if(collision.gameObject.tag == "Player")
        {

            collision.gameObject.GetComponent<PlayerDeathCondition>().Kill();
        }
    }
}
