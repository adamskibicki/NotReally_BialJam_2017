
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IResetGame
{
    [SerializeField]
    Timer timeSlider;
    [SerializeField]
    GameObject players;
    [SerializeField]
    CameraMoving cameraMoving;

    public float currentZValue { get; private set; }

    public void OnResetGame()
    {
        currentZValue = 0;
        timeSlider.AddActionOnResetTimer(TurnMap);
    }

    private void Start()
    {
        OnResetGame();
    }

    void TurnMap()
    {
        List<PlayerRotation> rotations = FindObjectsOfType<PlayerRotation>().ToList();
        List<PlayerMoving> movings = FindObjectsOfType<PlayerMoving>().ToList();

        Debug.Log("Rotations " + rotations.Count);
        int turnValue = UnityEngine.Random.Range(1, 4);
        currentZValue += turnValue*90;

        foreach (PlayerMoving moving in movings)
            moving.SnapToGrid();

        foreach (PlayerRotation rotate in rotations)
            rotate.Rotate(currentZValue);

        cameraMoving.MoveDirection(new Vector3(0, 0, currentZValue));
    }
}
