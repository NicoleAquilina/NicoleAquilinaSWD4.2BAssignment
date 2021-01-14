using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int gamePoints = 0;

    private void Awake()
    {
        SetUpSingleton();
    }

    //to make sure that only 1 GameSession is running
    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    //get the value of gamePoints
    public int GetPoints()
    {
        return gamePoints;
    }

    //add Value to gamePoints
    public void AddToScore(int scoreValue)
    {
        gamePoints += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }


}
