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

    private bool canProcessCollision = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canProcessCollision && collision.gameObject.CompareTag("Toad"))
        {
            StartCoroutine(ProcessCollision(collision.gameObject));
        }
    }

    private IEnumerator ProcessCollision(GameObject collidedObject)
    {
        canProcessCollision = false;

        collidedObject.GetComponent<Health>().addHealth(1);
        audioManager.PlaySFX(audioManager.Collection_Items);
        gameObject.SetActive(false);

        yield return new WaitForSeconds(1.0f); 

        canProcessCollision = true;
    }
}
