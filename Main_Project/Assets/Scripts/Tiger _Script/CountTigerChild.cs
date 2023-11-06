using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTigerChild : MonoBehaviour
{
    [SerializeField] Text pointText;
    int points = 0;
    GameObject Toad;
    Rigidbody2D ToadRigidbody2D;

    private void Start()
    {
        Toad = GameObject.FindGameObjectWithTag("Toad");
        ToadRigidbody2D = Toad.GetComponent<Rigidbody2D>();
    }

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tiger Child") && !(ToadRigidbody2D.velocity.y < -0.5f))
        {
            points++;
            UpdateHUD();
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Tiger Child") && !(ToadRigidbody2D.velocity.y < -0.5f))
    //    {
    //        points++;
    //        UpdateHUD();
    //    }
    //}
}
