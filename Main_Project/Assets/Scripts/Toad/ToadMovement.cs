using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToadMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    float dirX;
    // Start is called before the first frame update

    private enum MovementState {stay, jump, tongue, fall };
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (rb != null)
        {
            rb.velocity = new Vector2(dirX * 7f, rb.velocity.y);
        }
        else
        {
            Debug.LogError("Rigidbody2D is not attached to the Toad game object.");
        }


        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 14f);
        }
        AnimationUpdate();


    }

    private void AnimationUpdate()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.jump;
            spriteRenderer.flipX = true;
        }
        else if (dirX < 0f)
        {
            state = MovementState.jump;
            spriteRenderer.flipX = false;
        }
        else
        {
            state = MovementState.stay;

        }

        if(rb.velocity.y > .1f)
        {

        }
    }
}
