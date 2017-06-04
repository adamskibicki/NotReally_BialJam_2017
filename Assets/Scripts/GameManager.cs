
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour, IResetGame
{
    [SerializeField]
    Timer timeSlider;
    [SerializeField]
    GameObject players;
    [SerializeField]
    CameraMoving cameraMoving;
    [SerializeField]
    GameReset resetGame;

    public float CurrentZValue { get; private set; }

    public void OnResetGame()
    {
        CurrentZValue = 0;
        timeSlider.AddActionOnResetTimer(TurnMap);
    }

    public void ResetGame()
    {
        resetGame.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
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
        CurrentZValue += turnValue*90;

        foreach (PlayerMoving moving in movings)
            moving.SnapToGrid();

        foreach (PlayerRotation rotate in rotations)
            rotate.Rotate(CurrentZValue);

        cameraMoving.MoveDirection(new Vector3(0, 0, CurrentZValue));
    }
}
