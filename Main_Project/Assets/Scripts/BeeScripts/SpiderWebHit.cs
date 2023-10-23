using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWebHit : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private BoxCollider2D playerBoxcollider;
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer spriteRenderer;
    private bool isColliding = false;
    private Color initialColor;
    [SerializeField] SwitchPlayer switchPlayer;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;
    }

    private void Update()
    {
        if (!isColliding)
        {
            boxCollider.isTrigger = false;
            spriteRenderer.color = initialColor;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Toad"))
        {
            ConfigToadSpiderWeb();
            switchPlayer.UpdateLockKeyCode();

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Toad"))
        {
            isColliding = false;
            switchPlayer.ResetLockKeyCode();
        }
    }

    private void ConfigToadSpiderWeb()
    {
        boxCollider.isTrigger = true;

        Color newColor = spriteRenderer.color;
        newColor.a = 0.5f;
        spriteRenderer.color = newColor;

        isColliding = true;
    }
}
