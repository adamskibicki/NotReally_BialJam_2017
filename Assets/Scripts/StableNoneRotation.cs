using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableNoneRotation : MonoBehaviour
{
    void Update()
    {
        if (transform.eulerAngles != new Vector3(0, 0, 0))
            transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
