using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToadDie : MonoBehaviour
{
    Vector2 StartPosition;
    private new Rigidbody2D rigidbody2D;
    private new Animator animation;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
        rigidbody2D = GetComponent<Rigidbody2D>(); 
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Death"))
        {
            Die();
        }
    }

    public void UpdateCheckPoint(Vector2 checkPoint)
    {
        StartPosition = checkPoint;
    }

    private void Die()
    {
        animation.SetTrigger("death");
        StartCoroutine(AfterDie(0.5f));
    }
     
    IEnumerator AfterDie(float duration)
    {
        rigidbody2D.simulated = false;
        yield return new WaitForSeconds(duration);
        transform.position = StartPosition;
        yield return new WaitForSeconds(duration);
        animation.Play("StayToad");
        rigidbody2D.simulated = true;
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }
}
