using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollection : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Toad"))
        {
            collision.GetComponent<Health>().addHealth(1);
            audioManager.PlaySFX(audioManager.Collection_Items);
            gameObject.SetActive(false);
        }
    }
}
