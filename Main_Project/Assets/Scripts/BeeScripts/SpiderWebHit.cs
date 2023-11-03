using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWebHit : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private Color initialColor;
    [SerializeField] SwitchPlayer switchPlayer;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;
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
            boxCollider.isTrigger = false;
            spriteRenderer.color = initialColor;
            switchPlayer.ResetLockKeyCode();
        }
    }

    private void ConfigToadSpiderWeb()
    {
        boxCollider.isTrigger = true;

        Color newColor = spriteRenderer.color;
        newColor.a = 0.5f;
        spriteRenderer.color = newColor;
    }

    private IEnumerator DelayWithCoroutine(float delayTime)
    {
        
        yield return new WaitForSeconds(delayTime);
    }
}
