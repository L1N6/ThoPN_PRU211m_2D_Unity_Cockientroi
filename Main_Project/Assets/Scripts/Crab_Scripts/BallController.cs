using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public new Rigidbody2D rigidbody2D;
    public float speed = 300;

    private Vector2 velocity;

    Vector2 startPosition;

    public AudioSource audioSource;
    public AudioClip paddleSound, brickSound, wallSound, deadZoneSound;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        
        ResetBall(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadZone"))
        {
            audioSource.clip = deadZoneSound;
            audioSource.Play();
            FindObjectOfType<GameManager>().LosseHealth();
        }
        if (collision.gameObject.GetComponent<PaddleController>())
        {
            audioSource.clip = paddleSound;
            audioSource.Play();
        }
        if (collision.gameObject.GetComponent<BricksController>())
        {
            audioSource.clip = brickSound;
            audioSource.Play();
        }
        if (collision.transform.CompareTag("Wall"))
        {
            audioSource.clip = wallSound;
            audioSource.Play();
        }
        
    }

    public void ResetBall()
    {
        transform.position = startPosition;
        rigidbody2D.velocity = Vector2.zero;

        velocity.x = Random.Range(-1f, 1f);

        velocity.y = 1;

        rigidbody2D.AddForce(velocity * speed);
    }
}
