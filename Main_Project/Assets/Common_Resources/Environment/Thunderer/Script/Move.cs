using Assets.Common_Resources.Environment.Thunderer.Script;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    // saved for efficiency
    float colliderHalfWidth;
    float colliderHalfHeight;
    public Transform player;
    public bool isFlipped = false;

    Animator animator;
    // movement support
    const float MoveUnitsPerSecond = 5;
    private Rigidbody rb;
    /// <summary>
	/// Start is called before the first frame update
	/// </summary>	
    void Start()
    {
        //rb.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isFlipped = false;
        // save for efficiency
        //BoxCollider2D collider = GetComponent<BoxCollider2D>();
        //colliderHalfWidth = collider.size.x / 2;
        //colliderHalfHeight = collider.size.y / 2;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>	
    public void OnAttackAnimationEnd()
    {
        // Reset the attack boolean parameter
        //animator.SetBool("attack", false);

        // Transition back to the previous animation state
    }


    public bool isGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 3f, 1 << 8);
        if (hitInfo.collider != null)
        {

        }
        return true;
    }
    public void returnIdleAnimation()
    {
        animator.SetBool("attack", false);
        animator.SetBool("jump", false);
    }
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.E))
        {
            animator.SetBool("attack", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.Play("jump", -1, 0f);
            animator.SetTrigger("idle");
            // animator.SetBool("jump", true);
        }

        else
        {

        }

        // move game object as appropriate
        Vector3 position = transform.position;
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if (horizontalInput != 0)
        {
            //Vector3 flipped = transform.localScale;
            //flipped.z *= -1f;

            if (horizontalInput > 0)
            {
                Debug.Log("Keep Object " + isFlipped);

                if (isFlipped == true)
                {
                    //transform.localScale = flipped;
                    transform.Rotate(0f, 180f, 0f);
                }
                isFlipped = false;

                position.x += horizontalInput * MoveUnitsPerSecond * Time.deltaTime;

            }
            else if (horizontalInput < 0)
            {
                Debug.Log("Rotate Object " + isFlipped);

                if (isFlipped == false)
                {

                    // transform.localScale = flipped;
                    transform.Rotate(0f, 180f, 0f);
                }
                isFlipped = true;
                position.x += horizontalInput * MoveUnitsPerSecond * Time.deltaTime;


            }

            animator.SetBool("run", true);


            position.x += horizontalInput * MoveUnitsPerSecond *
              Time.deltaTime;
        }

        if (verticalInput != 0)
        {

            //animator.SetBool("run", true);

            position.y += verticalInput * MoveUnitsPerSecond *
                 Time.deltaTime;
        }
        if (verticalInput == 0 && horizontalInput == 0)
        {
            animator.SetBool("run", false);
        }

        // move character
        transform.position = position;
        ClampInScreen();
    }

    /// <summary>
    /// Clamps the character in the screen
    /// </summary>
    void ClampInScreen()
    {
        Vector3 position = transform.position;

        // clamp horizontally
        if (position.x - colliderHalfWidth < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenLeft + colliderHalfWidth;
        }
        else if (position.x + colliderHalfWidth > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenRight - colliderHalfWidth;
        }

        // clamp vertically
        if (position.y + colliderHalfHeight > ScreenUtils.ScreenTop)
        {
            position.y = ScreenUtils.ScreenTop - colliderHalfHeight;
        }
        else if (position.y - colliderHalfHeight < ScreenUtils.ScreenBottom)
        {
            position.y = ScreenUtils.ScreenBottom + colliderHalfHeight;
        }

        transform.position = position;
    }
}
