
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum Quest
{
    Kill,
    SurviveTime,
    SurviveChanges
}


public class GameManager : Singleton<GameManager>
{

    [SerializeField]
    Timer timeSlider;
    [SerializeField]
    GameObject players;
    [SerializeField]
    CameraMoving cameraMoving;

    [SerializeField]
    Text changesToWinText;

    int amountChangesToWin;

    float currentZValue;

    private void Start()
    {
        currentZValue = 0;
        amountChangesToWin = 5;
        timeSlider.AddActionOnResetTimer(TurnMap);
        timeSlider.AddActionOnResetTimer(DecreaseChangesToWin);
    }

    void TurnMap()
    {
        List<PlayerRotation> rotations = FindObjectsOfType<PlayerRotation>().ToList();

        Debug.Log("Rotations " + rotations.Count);
        int turnValue = UnityEngine.Random.Range(1, 4);
        Vector3 turnVector = new Vector3(0, 0, 90 * turnValue);


        foreach (PlayerRotation rotate in rotations)
            rotate.Rotate(turnVector);

        currentZValue += turnVector.z;
        cameraMoving.MoveDirection(new Vector3(0, 0, currentZValue));
    }

    void DecreaseChangesToWin()
    {
        amountChangesToWin--;
        changesToWinText.text = amountChangesToWin.ToString();
        if (amountChangesToWin <= 0)
        {
            Win();
        }
    }

    private void Win()
    {

    }
}
