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
        Instantiate(ninjaPrefab, spawnPoint.transform.position, new Quaternion(), playersContainer.transform);
    }
}
