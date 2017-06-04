using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputName : MonoBehaviour
{
    [SerializeField]
    Text inputNameField;

    [SerializeField]
    Scoreboard scoreboardScript;

    public void ShowScoreboard()
    {
        Debug.Log(inputNameField.text + " nick postaci");
        scoreboardScript.SetCharacterName(inputNameField.text);
        scoreboardScript.ShowScoreBoard();
    }
}
