using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{

    [SerializeField]
    CoinsManager coinsManager;
    [SerializeField]
    Transform scoreTextsContainer;

    [SerializeField]
    GameObject inputModal;
    [SerializeField]
    GameObject scoreModal;

    int value;
    string nameOfCharacter;

    public void SetCharacterName(string name)
    {
        nameOfCharacter = name;
    }

    public void ShowScoreBoard()
    {
        value = coinsManager.GetScore();

        Debug.Log("Value " + value + " name " + nameOfCharacter);
        List<Score> board = new List<Score>();
        SetScoreboard(board);

        board = board.OrderByDescending(x => x.ScoreValue).ToList();
        foreach (Score x in board)
            Debug.Log(x.ScoreValue + " " + x.Name);

        SaveValues(board);
        SetValuesOnBoard(board);
        ShowBoard();
    }

    private void ShowBoard()
    {
        inputModal.SetActive(false);
        scoreModal.SetActive(true);
    }

    private void SetValuesOnBoard(List<Score> board)
    {
        for (int i = 0; i < 5; i++)
        {
            scoreTextsContainer.GetChild(i).GetComponent<Text>().text =
                (i + 1).ToString() + ". " + board[i].Name + " " + board[i].ScoreValue;
        }
    }

    private void SetScoreboard(List<Score> board)
    {
        for (int i = 0; i < 5; i++)
        {
            board.Add(new Score(PlayerPrefs.GetString((i + 1).ToString() + "N"), PlayerPrefs.GetInt((i + 1).ToString())));
        }
        board.Add(new Score(nameOfCharacter, value));


    }

    private static void SaveValues(List<Score> board)
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetString((i + 1).ToString() + "N", board[i].Name);
            PlayerPrefs.SetInt((i + 1).ToString(), board[i].ScoreValue);
        }
        PlayerPrefs.Save();
    }

    class Score
    {
        public int ScoreValue { get; private set; }
        public string Name { get; private set; }

        public Score(string name, int score)
        {
            Name = name;
            ScoreValue = score;
        }
    }
}
