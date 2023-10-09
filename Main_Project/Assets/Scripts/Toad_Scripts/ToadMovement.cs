using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToadMovement : MonoBehaviour
{

    public Rigidbody2D rb; 
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private new BoxCollider2D collider2D;
    private float dirX;
    private float moveSpeed = 7f;
    private float jumpForce = 19f;
    // Start is called before the first frame update

    [SerializeField] private LayerMask jumpableGround;    

    private enum MovementState {stay, shortJump, highJump, fall, tongue};
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic; 
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (rb != null)
        {
            rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }
        else
        {
            Debug.LogError("Rigidbody2D is not attached to the Toad game object.");
        }


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        AnimationUpdate();


    }

    private void AnimationUpdate()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.shortJump;
            spriteRenderer.flipX = true;
        }
        else if (dirX < 0f)
        {
            state = MovementState.shortJump;
            spriteRenderer.flipX = false;
        }
        else
        {
            state = MovementState.stay;

        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.highJump;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(collider2D.bounds.center, collider2D.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
