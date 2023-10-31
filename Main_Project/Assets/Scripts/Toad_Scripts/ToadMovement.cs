using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ToadMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private new CapsuleCollider2D collider2D;
    private float dirX;
    private float moveSpeed = 7f;
    public float jumpForce = 19f;

    
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }
    

    private enum MovementState { stay, shortJump, highJump, fall, tongue };
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueUI.IsOpen)
        {
            return;
        }

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

        if (Input.GetKey(KeyCode.E))
        {
            Interactable?.Interact(this);
        }

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

        if (rb.velocity.y > .1f)
        {
            state = MovementState.highJump;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.fall;
        }
        else if (rb.velocity.y < -.1f)
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
