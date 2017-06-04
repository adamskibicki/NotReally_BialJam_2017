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

    private void OnGUI()
    {
        int coins = GameObject.FindGameObjectWithTag("GameController").GetComponent<CoinsManager>().GetCoinsAmount();
        int width = 200;
        int height = 150;
        if (lost)
        {
            if(GUI.Button(new Rect(Screen.width / 2 - width / 2, Screen.height / 2 - height / 2, width, height), "You got " + coins + " coins!"))
            {
                ResetGameNow();
            }
        }
    }

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

        StartCoroutine(WaitThenShowButton());
    }

    private IEnumerator WaitThenShowButton()
    {
        yield return new WaitForSeconds(1f);
        lost = true;
    }

    private void ResetGameNow()
    {
        resetGame.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
