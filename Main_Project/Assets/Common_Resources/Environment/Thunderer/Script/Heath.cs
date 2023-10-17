using UnityEngine;

public class Heath : MonoBehaviour
{
    [SerializeField] private int health = 10;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("abc");
    }

    public void TakeDamage()
    {

        if (health <= 0)
        {
            Die();
        }
        else
        {
            Debug.Log("Heath Lost");
            health -= 1;
        }
    }
    private void Die()
    {
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
