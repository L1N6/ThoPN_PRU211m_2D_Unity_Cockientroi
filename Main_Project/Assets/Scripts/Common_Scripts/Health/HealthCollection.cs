using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Toad"))
        {
            collision.GetComponent<Health>().addHealth(1);
            gameObject.SetActive(false);
        }
    }
}
