using UnityEngine;

public class Health : MonoBehaviour
{
    GameObject Toad;
    Rigidbody2D ToadRigidbody2D;
    private new Animator animation;
    [SerializeField] private float startingHealth;
    public float currenthealth { get; private set; }

    private void Start()
    {
        currenthealth = startingHealth;
        animation = GetComponent<Animator>();
        Toad = GameObject.FindGameObjectWithTag("Toad");
        ToadRigidbody2D = Toad.GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - damage, 0, startingHealth);

        if (currenthealth == 0)
        {
            Debug.Log("Game Over");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !(ToadRigidbody2D.velocity.y < -0.5f))
        {
            TakeDamage(1);
        }
    }

    public void addHealth(float value)
    {
        currenthealth = Mathf.Clamp(currenthealth + value, 0, startingHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Death") || collision.gameObject.CompareTag("Trap")) && !collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }
}
