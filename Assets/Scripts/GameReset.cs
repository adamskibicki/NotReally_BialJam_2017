using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReset : MonoBehaviour {

    public void ResetGame()
    {
        List<IResetGame> resetableObjects = new List<IResetGame>();
        var components = FindObjectsOfType<MonoBehaviour>();
        foreach (var component in components)
        {
            if (component is IResetGame)
                resetableObjects.Add(component as IResetGame);
        }
        foreach (IResetGame r in resetableObjects)
            r.OnResetGame();
    }
}
