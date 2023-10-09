using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitAction : MonoBehaviour
{
    GameObject Toad;
    GameObject Enemy;
    Animator ToadAnimation;
    Animator EnemyAnimation;
    Rigidbody2D ToadRigidbody2D;
    private Vector2 previousPosition;
    private Vector2 nextPosition;
    void Start()
    {
        previousPosition = transform.position;
        Toad = GameObject.FindGameObjectWithTag("Toad");
        Enemy = this.gameObject;
        EnemyAnimation = GetComponent<Animator>();
        ToadAnimation = Toad.GetComponent<Animator>();
        ToadRigidbody2D = Toad.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        nextPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Toad"))
        {
            StartCoroutine(GetHit());
        }
    }

    IEnumerator GetHit()
    {
        Vector2 currentPosition = Toad.transform.position;


        if ((ToadRigidbody2D.velocity.y < -0.5f) && (Enemy.transform.position.y < Toad.transform.position.y))
        {
            EnemyAnimation.Play("Dead");
            yield return new WaitForSeconds(0.01f);
            Destroy(this.GameObject());
            Jump();
        }
        else if (nextPosition.x > previousPosition.x)
        {
            currentPosition.x += 1.5f;
            yield return StartCoroutine(AfterHit(0.3f, currentPosition));
        }
        else if (nextPosition.x < previousPosition.x)
        {
            currentPosition.x -= 1.5f;
            yield return StartCoroutine(AfterHit(0.3f, currentPosition));
        }
        else
        {
            currentPosition.y -= 1.5f;
            yield return StartCoroutine(AfterHit(0.3f, currentPosition));
        }
    }

    IEnumerator AfterHit(float time, Vector2 currentPosition)
    {
        ToadAnimation.Play("EnemiesHit");
        Toad.transform.position = currentPosition;
        yield return new WaitForSeconds(time);
        ToadAnimation.Play("StayToad");
    }

    private void Jump()
    {
        ToadRigidbody2D.velocity = new Vector2(ToadRigidbody2D.velocity.x, 16f);
        ToadAnimation.Play("HighJumpToad");
    }

}
