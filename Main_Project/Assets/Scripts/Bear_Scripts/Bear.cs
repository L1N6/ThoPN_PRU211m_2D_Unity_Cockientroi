using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    private int currentTreeIndex;
    bool isFacingRight;
    public float[] arr = {0f, -5.2f, -2.5f, -2.2f, 0.5f, 0.8f, 3.5f};
    public Rigidbody2D myBody;
    public BoxCollider2D boxCollider2D;
    void Start()
    {
        isFacingRight = true;
        currentTreeIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentTreeIndex != 1)
        {
            currentTreeIndex -= 1;
            move(arr[currentTreeIndex]);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentTreeIndex != 6)
        {
            currentTreeIndex += 1;
            move(arr[currentTreeIndex]);
        }

        
    }

    void rotateRight()
    {
        isFacingRight = false;
        transform.Rotate(Vector3.left, -180f);
    }

    void rotateLeft()
    {
        isFacingRight = true;
        transform.Rotate(Vector3.right, 180f);
    }

    void move(float x)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
        if (isFacingRight)
        {
            rotateRight();
        }
        else
        {
            rotateLeft();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            myBody.gravityScale = 1f;
            boxCollider2D.isTrigger = true;
        }
    }


}
