using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayersObserver : MonoBehaviour
{
    int players = 0;
    bool lost = false;

    [SerializeField]
    Text playersLeftText;
    [SerializeField]
    GameReset resetGame;

    void Update ()
    {
        CountChildren();
        UpdateUI();
    }

    private void CountChildren()
    {
        int child = transform.childCount;
        players = 0;
        for (int i = 0; i < child; i++)
        {
            if (transform.GetChild(i).tag == "Player")
                players++;
        }

        if (players == 0)
        {
            Lose();
        }
    }

    private void UpdateUI()
    {
        playersLeftText.text = players.ToString();
    }

    private void Lose()
    {
        lost = true;
        StartCoroutine(WaitThenShowButton());
    }

    private IEnumerator WaitThenShowButton()
    {
        yield return new WaitForSeconds(1f);
    }

    private void ResetGameNow()
    {
        resetGame.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
