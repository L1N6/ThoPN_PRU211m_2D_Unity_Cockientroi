using UnityEngine;

public class ChildBulletImpact : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator bulletAnimator;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = Vector3.zero;
            bulletAnimator.Play("ChildBulletExplode", -1, 0f);

        }
    }
    private void destroyBullet()
    {
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {

    }
<<<<<<< HEAD
}
=======
}
>>>>>>> f451f09de3b8d973c3828b3821426a4dca373195
