using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public static readonly string ThundererPlayerPref = "Thunderer";
    public static readonly string TotalGameWin = "TotalGameWin";
    public static readonly string ToadPositionX = "ToadPositionX";
    public static readonly string ToadPositionY = "ToadPositionY";
    public static readonly string ToadPositionZ = "ToadPositionZ";
    [SerializeField] private GameObject Toad;

    public enum Animal
    {
        Toad,
        Bee,
        Bear,
        Fox,
        Crab,
        Tiger
    }

    public enum AfterLoseStatus
    {
        Bee_Waiting,
        Bear_Waiting,
        Fox_Waiting,
        Crab_Waiting,
        Tiger_Waiting
    }

    void Awake()
    {
        if (PlayerPrefs.GetFloat(ToadPositionX) != 0.0f && PlayerPrefs.GetFloat(ToadPositionY) != 0.0f)
        {
            SetToadPosition();
        }
    }

    private void SetToadPosition()
    {
        Toad.transform.position = new Vector3(PlayerPrefs.GetFloat(ToadPositionX), PlayerPrefs.GetFloat(ToadPositionY), PlayerPrefs.GetFloat(ToadPositionZ));
    }

    public void UpdateAnimalWinStatus(string animalName)
    {
        PlayerPrefs.SetInt(animalName, 1);
        PlayerPrefs.SetInt(TotalGameWin, PlayerPrefs.GetInt(TotalGameWin) + 1);
        foreach (AfterLoseStatus Name in Enum.GetValues(typeof(AfterLoseStatus)))
        {
            PlayerPrefs.SetInt(Name.ToString(), 0);
        }
    }

    public void UpdateAnimalAfterLoseStatus(string animalNameWaiting)
    {
        PlayerPrefs.SetInt(animalNameWaiting, 1);
    }

    public void UpdateThundererWinStatus()
    {
        PlayerPrefs.SetInt(ThundererPlayerPref, 1);
    }
}
