using Assets.Common_Resources.Environment.Thunderer.Script;
using UnityEngine;

public class Move : MonoBehaviour
{
    // saved for efficiency
    float colliderHalfWidth;
    float colliderHalfHeight;
    public Transform player;
    public bool isFlipped = false;
    Animator animator;
    // movement support
    const float MoveUnitsPerSecond = 5;

    /// <summary>
	/// Start is called before the first frame update
	/// </summary>	
    void Start()
    {
        animator = GetComponent<Animator>();
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
        animator.SetBool("attack", false);

        // Transition back to the previous animation state
    }
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("attack", true);
        }

        // move game object as appropriate
        Vector3 position = transform.position;
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (horizontalInput != 0)
        {
            Vector3 flipped = transform.localScale;
            flipped.z *= -1f;

            if (horizontalInput > 0)
            {
                Debug.Log("Keep Object");

                if (isFlipped == true)
                {
                    transform.localScale = flipped;
                    transform.Rotate(0f, 0f, 0f);
                }
                isFlipped = false;

            }
            else if (horizontalInput < 0)
            {
                Debug.Log("Rotate Object");

                if (isFlipped == false)
                {
                    transform.localScale = flipped;
                    transform.Rotate(0f, 180f, 0f);
                }
                isFlipped = true;
            }

            animator.SetBool("run", true);

            position.x += horizontalInput * MoveUnitsPerSecond *
                Time.deltaTime;
        }
        else if (verticalInput != 0)
        {

            animator.SetBool("run", true);

            position.y += verticalInput * MoveUnitsPerSecond *
                Time.deltaTime;
        }
        else
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
