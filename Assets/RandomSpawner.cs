using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    public Transform CameraTransform;

    public int randMax = 5;
    public int randMin = 2;

    public GameObject[] ObstaclePrefabs;

    public static List<GameObject> freeObjects = new List<GameObject>();

    public Vector3 cameraInitialPosition;

    private Vector3 bottomLeft;

    private void Start()
    {
        Camera camera = Camera.main;

        cameraInitialPosition.x = Mathf.RoundToInt(cameraInitialPosition.x) * 4 + 2;
        cameraInitialPosition.y = Mathf.RoundToInt(cameraInitialPosition.y) * 4 + 2;

        bottomLeft = camera.ScreenToWorldPoint(new Vector3(0, 0));
    }

    private int prevoiusXOffset = 0;
    private int prevoiusYOffset = 0;

    private void Update()
    {
        int xOffset = (int)((CameraTransform.position.x - cameraInitialPosition.x) / 4);
        int yOffset = (int)((CameraTransform.position.y - cameraInitialPosition.y) / 4);

        float worldXOffset = Mathf.RoundToInt(Mathf.Abs(bottomLeft.x / 4)) * 4 + 10;
        float worldYOffset = Mathf.RoundToInt(Mathf.Abs(bottomLeft.y / 4)) * 4 + 10;

        if (xOffset > prevoiusXOffset)
        {
            prevoiusXOffset = xOffset;

            int y = 0;
            y += Random.Range(randMin, randMax);
            while (y * 4 <= worldYOffset * 2)
            {
                GameObject go = GetFreeObstacle();
                go.SetActive(true);
                go.transform.position = cameraInitialPosition + new Vector3(worldXOffset + xOffset * 4, -worldYOffset + y * 4 + yOffset * 4);
                int r = Random.Range(randMin, randMax);
                y += r;
            }
        }
        if (xOffset < prevoiusXOffset)
        {
            prevoiusXOffset = xOffset;

            int y = 0;
            y += Random.Range(randMin, randMax);
            while (y * 4 <= worldYOffset * 2)
            {
                GameObject go = GetFreeObstacle();
                go.SetActive(true);
                go.transform.position = cameraInitialPosition + new Vector3(-worldXOffset + xOffset * 4, -worldYOffset + y * 4 + yOffset * 4);
                int r = Random.Range(randMin, randMax);
                y += r;
            }
        }
        if (yOffset < prevoiusYOffset)
        {
            prevoiusYOffset = yOffset;

            int x = 0;
            x += Random.Range(randMin, randMax);
            while (x * 4 <= worldXOffset * 2)
            {
                GameObject go = GetFreeObstacle();
                go.SetActive(true);
                go.transform.position = cameraInitialPosition + new Vector3(-worldXOffset + x * 4 + xOffset * 4, -worldYOffset + yOffset * 4);
                int r = Random.Range(randMin, randMax);
                x += r;
            }
        }
        if (yOffset > prevoiusYOffset)
        {
            prevoiusYOffset = yOffset;

            int x = 0;
            x += Random.Range(randMin, randMax);
            while (x * 4 <= worldXOffset * 2)
            {
                GameObject go = GetFreeObstacle();
                if(go != null)
                {
                    go.SetActive(true);
                    go.transform.position = cameraInitialPosition + new Vector3(-worldXOffset + x * 4 + xOffset * 4, worldYOffset + yOffset * 4);
                    int r = Random.Range(randMin, randMax);
                    x += r;
                }
            }
        }
    }

    private GameObject GetFreeObstacle()
    {
        if (freeObjects.Count > 0)
        {
            GameObject last = freeObjects.Last();
            freeObjects.RemoveAt(freeObjects.Count - 1);
            return last;
        }
        else
        {
            GameObject nw = Instantiate(GetRandomObstaclePrefab());
            return nw;
        }
    }

    private GameObject GetRandomObstaclePrefab()
    {
        return ObstaclePrefabs[Random.Range(0, ObstaclePrefabs.Length)];
    }

    public enum MoveDirection
    {
        Up,
        Down,
        Left,
        Right
    }
}
