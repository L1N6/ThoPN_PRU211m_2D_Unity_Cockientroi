using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;

    private float inputValue;

    public float moveSpeed = 25;

    private Vector2 direction;

     Vector2 startPosition;

    private Animator animator;
    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        inputValue = Input.GetAxisRaw("Horizontal");
        if (inputValue == 1)
        {
            direction = Vector2.right;
        }
        else if (inputValue == -1)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.zero;
        }
        animator.SetFloat("CrabMove", Mathf.Abs(inputValue));
        rigidBody2D.AddForce(direction * moveSpeed * Time.deltaTime * 100);

    }

    public void ResetPaddle()
    {
        transform.position = startPosition;
        rigidBody2D.velocity = Vector2.zero;
    }
}
