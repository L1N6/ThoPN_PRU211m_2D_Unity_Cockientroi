using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    GameObject Toad;
    Rigidbody2D ToadRigidbody2D;
    [SerializeField] private float startingHealth;
    [SerializeField] GameObject LoseCanvas;
    public float currenthealth { get; private set; }

    private void Start()
    {
        currenthealth = startingHealth;
        Toad = GameObject.FindGameObjectWithTag("Toad");
        ToadRigidbody2D = Toad.GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - damage,0, startingHealth);
        if(currenthealth == 0)
        {
            LoseCanvas.SetActive(true);
            ToadRigidbody2D.simulated = false;
        }
    }
    public void addHealth(float value)
    {
        if(currenthealth == startingHealth)
        {
            return;
        }
        currenthealth = Mathf.Clamp(currenthealth + value, 0, startingHealth);
    }

    private bool canProcessCollision = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canProcessCollision)
        {
            StartCoroutine(ProcessCollision(collision.gameObject));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canProcessCollision)
        {
            StartCoroutine(ProcessCollision(collision.gameObject));
        }
    }

    private IEnumerator ProcessCollision(GameObject collidedObject)
    {
        canProcessCollision = false;

        if (collidedObject.CompareTag("Death") || collidedObject.CompareTag("Trap") ||
            (collidedObject.CompareTag("Enemy") && !(ToadRigidbody2D.velocity.y < -0.5f)))
        {
            Debug.Log("Collision or Trigger 2D");
            TakeDamage(1);
        }

        yield return new WaitForSeconds(0.2f); 

        canProcessCollision = true;
    }
}
