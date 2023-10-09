using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] lifes;
    public int lifeRemaining;

    public void LoseLife()
    {
        if (lifeRemaining == 0)
        {
            return;
        }

        lifeRemaining--;
        lifes[lifeRemaining].enabled = false;

        if (lifeRemaining == 0)
        {
            Debug.Log("YOU LOST!!!");
        }
    }

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Return))
    //    {
    //        LoseLife();
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Death"))
        {
            LoseLife();
        }
    }
}
