using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public new Rigidbody2D rigidbody2D;
    public float speed = 250;
    private Vector2 velocity;
    Vector2 startPosition;
    Vector3 lastVelocity;
    private bool check = true;

    public AudioSource audioSource;
    public AudioClip paddleSound, brickSound, wallSound, deadZoneSound;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

        ResetBall();
    }

    private void Update()
    {
        lastVelocity = rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            audioSource.clip = deadZoneSound;
            audioSource.Play();
            FindObjectOfType<CrabGameManager>().LosseHealth();
            check = false;
        }
        if (collision.gameObject.GetComponent<PaddleController>() && check)
        {
            audioSource.clip = paddleSound;
            audioSource.Play();
        }
        if (collision.gameObject.GetComponent<BricksController>())
        {
            audioSource.clip = brickSound;
            audioSource.Play();
            check = true;
        }
        if (collision.transform.CompareTag("Wall"))
        {
            audioSource.clip = wallSound;
            audioSource.Play();
            check = true;
        }

    }


    public void ResetBall()
    {
        transform.position = startPosition;
        rigidbody2D.velocity = Vector2.zero;

        velocity.x = 1;

        velocity.y = 1;

        rigidbody2D.AddForce(velocity * speed);
    }
}
