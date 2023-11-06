using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterWinAnimal : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt(GameManagement.Animal.Bee.ToString()) == 1 && tag == "Bee")
        {
            gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt(GameManagement.Animal.Bear.ToString()) == 1 && tag == "Bear")
        {
            gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt(GameManagement.Animal.Fox.ToString()) == 1 && tag == "Fox")
        {
            gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt(GameManagement.Animal.Crab.ToString()) == 1 && tag == "Crab")
        {
            gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt(GameManagement.Animal.Tiger.ToString()) == 1 && tag == "Tiger")
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
