using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BricksController : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Childcount " + transform.childCount);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {

            Destroy(transform.gameObject);

            FindObjectOfType<GameManager>().CheckCrabGameComplete();

            

        }
    }
}
