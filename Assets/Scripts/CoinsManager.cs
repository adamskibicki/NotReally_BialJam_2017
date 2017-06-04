using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour, IResetGame
{
    int currentLevel;
    int coinsAchieved;

    [SerializeField]
    Text currentLevelText;

    [SerializeField]
    Text coinsAchievedText;

    [SerializeField]
    NinjaSpawner spawner;

    private void Start()
    {
        OnResetGame();
    }

    public void OnResetGame()
    {
        coinsAchieved = 0;
        currentLevel = 1;
    }

    public void CoinAchieved()
    {
        coinsAchieved++;
        CheckNextLevel();
        UpdateUI();
    }

    private void CheckNextLevel()
    {
        if (coinsAchieved == Mathf.RoundToInt(Mathf.Pow(currentLevel, 1.5f))) 
        {
            currentLevel++;
            spawner.Spawn();
            UpdateUI();
        }
    }

    public int GetCoinsAmount()
    {
        return coinsAchieved;
    }

    void UpdateUI()
    {
        coinsAchievedText.text = coinsAchieved.ToString();
        currentLevelText.text = currentLevel.ToString();
    }
}
