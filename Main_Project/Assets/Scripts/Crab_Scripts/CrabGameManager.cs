using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrabGameManager : MonoBehaviour
{
    public int lives = 3, number=0;
    public AudioSource audioSource;
    List<GameObject> heartList = new List<GameObject>();
    private void Start()
    {
        Debug.Log("childcount " + transform.childCount);
        audioSource.Play();
        
        for(int i = 0; i<3; i++)
        {
            heartList.Add(GameObject.Find($"Heart{i}"));
                
        }
    }

    public void LosseHealth()
    {
        lives--;
        Destroy(heartList[number]);
        number++;
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
