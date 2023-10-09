using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public AudioSource audioSource;

    private void Start()
    {
        Debug.Log("childcount " + transform.childCount);
        audioSource.Play();
    }

    public void LosseHealth()
    {
        lives--;

        if(lives <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            ResetLevel();
        }
    }

    private void ResetLevel()
    {
        FindObjectOfType<BallController>().ResetBall();
        FindObjectOfType<PaddleController>().ResetPaddle();
    }

    public void CheckCrabGameComplete()
    {

        if (transform.childCount <= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
