using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayersObserver : MonoBehaviour
{
    int players = 0;

    [SerializeField]
    Text playersLeftText;
    [SerializeField]
    GameReset resetGame;

    [HideInInspector]
    public bool left;
    [HideInInspector]
    public bool right;
    [HideInInspector]
    public float vertical;

    [SerializeField]
    GameObject inputModal;

    void Update ()
    {
        CountChildren();
        UpdateUI();

        left = Input.GetKeyDown(KeyCode.A);
        right = Input.GetKeyDown(KeyCode.D);
        vertical = Input.GetAxis("Vertical");
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
            Lose();
    }

    private void UpdateUI()
    {
        playersLeftText.text = players.ToString();
    }

    private void Lose()
    {
        StartCoroutine(WaitThenReload());
    }

    private IEnumerator WaitThenReload()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
        inputModal.SetActive(true);
    }
}
