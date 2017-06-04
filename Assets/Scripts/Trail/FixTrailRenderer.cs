using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixTrailRenderer : MonoBehaviour
{
	void Awake ()
    {
        TrailRenderer go = gameObject.GetComponent<TrailRenderer>();
        go.sortingLayerName =  "Player";
        go.sortingOrder = 1;
    }
}
