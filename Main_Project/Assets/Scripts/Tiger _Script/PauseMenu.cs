using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject outMenuUI;
    [SerializeField] GameObject LoseCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        Debug.Log("Pause");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        Debug.Log("Resume");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        outMenuUI.SetActive(true);

    }

    public void Yes()
    {
        outMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        LoseCanvas.SetActive(true);
    }
    public void No()
    {
        outMenuUI.SetActive(false);
        Resume();
    }

}

