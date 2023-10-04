using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 30f;

    [SerializeField] Rigidbody2D rb2D;

    private void Awake()
    {
        rb2D= GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, 0);
    }
}
