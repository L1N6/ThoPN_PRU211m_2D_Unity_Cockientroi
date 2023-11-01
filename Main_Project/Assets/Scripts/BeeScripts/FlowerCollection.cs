using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCollection : MonoBehaviour
{
    [SerializeField] private AudioManager AudioManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bee") || collision.gameObject.CompareTag("Toad"))
        {
            Destroy(gameObject);
            AudioManager.PlaySFX(AudioManager.Collection_Items);
        }
    }
}
