using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTracking : MonoBehaviour
{

    [SerializeField]
    GameObject objectToTrack;

    Vector3 startDifference;
    private void Start()
    {
        startDifference = transform.position - objectToTrack.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(objectToTrack.transform.position.x, objectToTrack.transform.position.y, -10) + startDifference;
    }
}