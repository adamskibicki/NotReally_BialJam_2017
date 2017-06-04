using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject spawnPoint;
    [SerializeField]
    GameObject ninjaPrefab;
    [SerializeField]
    GameObject playersContainer;

    internal void Spawn()
    {
        GameObject current = Instantiate(ninjaPrefab, spawnPoint.transform.position + new Vector3(0,0,10), new Quaternion(), playersContainer.transform);
    }
}
