using Assets.Common_Resources.Environment.Thunderer.Script;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    // saved for efficiency
    private GameObject attackArea = default;
    float colliderHalfWidth;
    float colliderHalfHeight;
    public Transform player;
    bool isFlipped = false;
    bool isRolling = false;
    float animationTimer = 0;
    [SerializeField] LayerMask layer;
    Animator animator;
    // movement support
    const float MoveUnitsPerSecond = 5;
    const float RollUnitPerSecond = 10;
    private Rigidbody2D rb;
    private Vector3 currentPosition;
    /// <summary>
	/// Start is called before the first frame update
	/// </summary>	
    void Start()
    {
        currentPosition = transform.position;
        attackArea = transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody2D>();
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

    public void MoveLeft()
    {
        if (isFlipped == false)
        {

            // transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
        }
        isFlipped = true;

        currentPosition.x += -1 * MoveUnitsPerSecond * Time.deltaTime;
        transform.position = currentPosition;
    }
    public void MoveRight()
    {

        if (isFlipped == true)
        {
            //transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
        }
        isFlipped = false;

        currentPosition.x += 1 * MoveUnitsPerSecond * Time.deltaTime;
        transform.position = currentPosition;
    }
    public void RollRight()
    {
        if (isRolling == false)
        {
            isRolling = true;
            isFlipped = false;
            animator.Play("roll", -1, 0f);
            currentPosition.x += 1 * RollUnitPerSecond * Time.deltaTime;
            transform.position = currentPosition;

        }


        if (isFlipped == true)
        {

            //transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
        }



    }

    public void RollLeft()
    {
        if (isRolling == false)
        {
            isRolling = true;
            isFlipped = true;
            animator.Play("roll", -1, 0f);
            currentPosition.x += -1 * RollUnitPerSecond * Time.deltaTime;
            transform.position = currentPosition;

        }
        if (isFlipped == false)
        {

            //transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public void ResetRolling()
    {
        isRolling = false;
    }

    public void Jump()
    {
        animator.Play("jump", -1, 0f);
        rb.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
    }

    public void roll()
    {
        animator.Play("roll", -1, 0f);
    }


    public bool isGrounded()
    {
        Vector3 rayCastPosition = transform.position;
        rayCastPosition.y += 0.1f;
        RaycastHit2D hitInfo = Physics2D.Raycast(rayCastPosition, -Vector2.up, 0.1f, layer);
        if (hitInfo.collider != null)
        {
            Debug.DrawRay(rayCastPosition, -transform.up * 0.1f, Color.green);

            return true;
        }
        Debug.DrawRay(rayCastPosition, -transform.up * 0.1f, Color.red);

        return false;
    }
    public void returnIdleAnimation()
    {
        animator.SetBool("attack", false);
        animator.SetBool("jump", false);
    }





    void Update()
    {

        //Debug.Log("Is ground:" + isGrounded());




        //else
        //{

        //}

        //// move game object as appropriate

        //float horizontalInput = Input.GetAxisRaw("Horizontal");
        //float verticalInput = Input.GetAxisRaw("Vertical");

        //if (horizontalInput != 0)
        //{
        //    //Vector3 flipped = transform.localScale;
        //    //flipped.z *= -1f;

        //    if (horizontalInput > 0)
        //    {


        //        if (isFlipped == true)
        //        {
        //            //transform.localScale = flipped;
        //            transform.Rotate(0f, 180f, 0f);
        //        }
        //        isFlipped = false;

        //        currentPosition.x += horizontalInput * MoveUnitsPerSecond * Time.deltaTime;

        //    }
        //    else if (horizontalInput < 0)
        //    {


        //        if (isFlipped == false)
        //        {

        //            // transform.localScale = flipped;
        //            transform.Rotate(0f, 180f, 0f);
        //        }
        //        isFlipped = true;
        //        currentPosition.x += horizontalInput * MoveUnitsPerSecond * Time.deltaTime;


        //    }

        //    animator.SetBool("run", true);


        //    currentPosition.x += horizontalInput * MoveUnitsPerSecond *
        //      Time.deltaTime;
        //}

        //if (verticalInput != 0)
        //{

        //    //animator.SetBool("run", true);

        //    currentPosition.y += verticalInput * MoveUnitsPerSecond *
        //         Time.deltaTime;
        //}
        //if (verticalInput == 0 && horizontalInput == 0)
        //{
        //    // animator.SetBool("run", false);
        //}

        // move character

        // ClampInScreen();
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
