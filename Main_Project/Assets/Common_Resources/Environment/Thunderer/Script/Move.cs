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

    }
}
