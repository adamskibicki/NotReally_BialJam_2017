using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixTrailRenderer : MonoBehaviour {
    
	void Start () {
        TrailRenderer go = gameObject.GetComponent<TrailRenderer>();
        go.sortingLayerName =  "Player";
        go.sortingOrder = 1;
    }
}
