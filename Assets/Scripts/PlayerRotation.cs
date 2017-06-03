using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public void Rotate(Vector3 rotationValue)
    {
        transform.Rotate(rotationValue);
    }
}
