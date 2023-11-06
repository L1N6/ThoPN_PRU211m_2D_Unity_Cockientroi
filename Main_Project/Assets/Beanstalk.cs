using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beanstalk : MonoBehaviour
{
    [SerializeField] GameObject BeanstalkLarge;
    void Start()
    {
        PlayerPrefs.SetInt(GameManagement.TotalGameWin, 5);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt(GameManagement.TotalGameWin) == 5)
        {
            BeanstalkLarge.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
