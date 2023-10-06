using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    GameObject player;
    Animator animation;
    Rigidbody2D rigidbody2D;
    ToadDie toadDie;
    Vector2 checkPointPosition;
    public Transform destination;
    public Transform respawnPosition;

    private void Start()
    {
        checkPointPosition = destination.position;
        player = GameObject.FindGameObjectWithTag("Toad");
        animation = player.GetComponent<Animator>();
        rigidbody2D = player.GetComponent<Rigidbody2D>();
        toadDie = GameObject.FindGameObjectWithTag("Toad").GetComponent<ToadDie>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Toad"))
        {
            if (Vector2.Distance(player.transform.position, transform.position) > 0.5f)
            {
                StartCoroutine(PortalIn());
                toadDie.UpdateCheckPoint(respawnPosition.position);
            }
        }
    }

    IEnumerator PortalIn()
    {
        rigidbody2D.simulated = false;
        animation.Play("Portal_In");
        StartCoroutine(MoveInPortal());
        yield return new WaitForSeconds(0.5f);
        player.transform.position = checkPointPosition;
        animation.Play("Portal_Out");
        yield return new WaitForSeconds(1f);
        animation.Play("StayToad");
        rigidbody2D.simulated = true;
    }

    IEnumerator MoveInPortal()
    {
        float timer = 0;
        while (timer < 0.5f)
        {
            player.transform.position = Vector2.MoveTowards(player.transform.position, transform.position, 3 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }
    }
}
