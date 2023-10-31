using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTigerChild : MonoBehaviour
{
    [SerializeField] Text pointText;
    int points = 0;

    private void Awake()
    {
        UpdateHUD();
    }
    public int Points
    {
        get
        {
            return points;
        }

        set
        {
            points = value;
            UpdateHUD();
        }
    }

    private void UpdateHUD()
    {
        pointText.text = points.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tiger Child"))
        {
            points += 1;
            UpdateHUD() ;
        }
    }
}
