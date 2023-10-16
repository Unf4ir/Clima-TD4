using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    private void Update()
    {
        if(PlayerStats.Lives <= 0 && !gameEnded)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        Debug.Log("Game Ended, GameManager");
        gameEnded = true;
    }
}
