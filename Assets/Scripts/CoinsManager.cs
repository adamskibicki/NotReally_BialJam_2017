using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
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
        coinsAchieved = 0;
        currentLevel = 1;
    }

    void AssignCoins()
    {
        CoinTrigger[] triggers = GameObject.FindObjectsOfType<CoinTrigger>();
        foreach (CoinTrigger trigger in triggers)
            trigger.AddOnTriggerAction(CoinAchieved);
    }

    public void CoinAchieved()
    {
        coinsAchieved++;
        CheckNextLevel();
        UpdateUI();
    }

    private void CheckNextLevel()
    {
        if (coinsAchieved == Mathf.Pow(currentLevel, 2))
        {
            currentLevel++;
            spawner.Spawn();
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        coinsAchievedText.text = coinsAchieved.ToString();
        currentLevelText.text = currentLevel.ToString();
    }
}
