﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour
{
    private GameObject ReplayButton;
    private GameObject QuitButton;

    public void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        ReplayButton = GameObject.Find("ReplayButton");
        QuitButton = GameObject.Find("QuitButton");

        ReplayButton.SetActive(false);
        QuitButton.SetActive(false);
        
    }

    public void ReplayLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void EnableMenu()
    {
        ReplayButton.SetActive(true);
        QuitButton.SetActive(true);
        Time.timeScale = 0;
    }
}