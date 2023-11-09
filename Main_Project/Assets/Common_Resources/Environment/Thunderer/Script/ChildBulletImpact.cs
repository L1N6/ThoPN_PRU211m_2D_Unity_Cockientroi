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

        rb.velocity = Vector3.zero;
        bulletAnimator.Play("ChildBulletExplode", -1, 0f);

        if (collision.gameObject.CompareTag("Toad"))
        {
            collision.GetComponent<Health>().TakeDamage(1);
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
}
