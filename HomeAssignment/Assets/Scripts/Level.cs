﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;
    public void LoadStartMenu()
    {
        //loads the first scene in the Project
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        //loads the scene with name Game
        SceneManager.LoadScene("Game");
        //reset the game from beginning
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }
    public void LoadWinner()
    {
        StartCoroutine(WaitAndLoad2());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameOver");
    }
    IEnumerator WaitAndLoad2()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Winner");
    }

}
