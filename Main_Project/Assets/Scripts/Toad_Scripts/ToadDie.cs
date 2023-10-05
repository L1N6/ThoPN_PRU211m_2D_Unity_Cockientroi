using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToadDie : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private new Animator animation;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); 
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        rigidbody2D.bodyType = RigidbodyType2D.Static;
        animation.SetTrigger("death");
    }
     
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
