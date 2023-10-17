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
    [SerializeField] LayerMask layer;
    Animator animator;
    // movement support
    const float MoveUnitsPerSecond = 5;
    private Rigidbody2D rb;
    /// <summary>
	/// Start is called before the first frame update
	/// </summary>	
    void Start()
    {
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
        Debug.Log("Is ground:" + isGrounded());

        if (Input.GetKeyUp(KeyCode.E))
        {
            attackArea.SetActive(true);
            animator.Play("1_atk", -1, 0f);
        }
        else if (isGrounded() && Input.GetKeyUp(KeyCode.Space))
        {
            animator.Play("jump", -1, 0f);
            rb.AddForce(new Vector2(0, 7), ForceMode2D.Impulse);
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
