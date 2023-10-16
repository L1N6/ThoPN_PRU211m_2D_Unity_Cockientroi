using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bear : MonoBehaviour
{
    private int currentTreeIndex;
    bool isFacingRight;
    public float[] arr = {0f, -5.2f, -2.5f, -2.2f, 0.5f, 0.8f, 3.5f};
    public Rigidbody2D myBody;
    public BoxCollider2D boxCollider2D;
    public int currentLives;
    public float speed = 4f;
    public bool isAlive;
    void Start()
    {
        isAlive = true;
        isFacingRight = true;
        currentTreeIndex = 1;
        currentLives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
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
        GameObject enemy = collision.gameObject;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(enemy);
            if(currentLives == 3)
            {
                Destroy(GameObject.Find("Heart3"));
            }
            if (currentLives == 2)
            {
                Destroy(GameObject.Find("Heart2"));
            }
            if (currentLives == 1)
            {
                Destroy(GameObject.Find("Heart1"));
            }
            currentLives -= 1;
            Debug.Log("Enemy: " + currentLives);
            if(currentLives == 0)
            {
                isAlive = false;
                myBody.gravityScale = 1f;
                boxCollider2D.isTrigger = true;
                Invoke("DelayedLoadScene", 1f);
            }
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("GameWin");
        }
    }
    void DelayedLoadScene()
    {
        Debug.Log("end");
        SceneManager.LoadScene("EndScene");
    }

}
