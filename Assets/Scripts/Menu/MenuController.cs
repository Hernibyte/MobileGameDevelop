﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartHS()
    {
        SceneManager.LoadScene("highScore");
    }

    public void StartCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
