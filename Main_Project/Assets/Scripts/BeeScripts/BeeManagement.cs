using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeManagement : MonoBehaviour
{
    private float dirX;
    private float dirY;
    [SerializeField] Vector2 StartPosition;
    public Rigidbody2D rb;
    private float moveSpeed = 10f;
    private new Animator animation;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Health health;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
            dirX = Input.GetAxisRaw("Horizontal");
            dirY = Input.GetAxisRaw("Vertical");
            if (rb != null)
            {
                rb.velocity = new Vector2(dirX * moveSpeed, dirY * moveSpeed);
            }
            AnimationUpdate();   
    }

    private void AnimationUpdate()
    {
        if (dirX > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0f)
        {
            spriteRenderer.flipX = true;
        }

    }

    private void BeeDie()
    {
        health.TakeDamage(1);
        animation.Play("BeeDie");
        StartCoroutine(AfterDie(0.5f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            BeeDie();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            BeeDie();
        }
    }

    IEnumerator AfterDie(float duration)
    {
        rb.simulated = false;
        yield return new WaitForSeconds(duration);
        transform.position = StartPosition;
        yield return new WaitForSeconds(0.1f);
        rb.simulated = true;
        animation.Play("StayBee");
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void UpdateStartPosition(Vector2 position)
    {
        StartPosition = position;
    }

}
