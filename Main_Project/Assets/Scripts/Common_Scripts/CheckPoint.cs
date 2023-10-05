using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    ToadDie toadDie;
    public Transform respawnPosition;
    private new Animator animation;

    private void Start()
    {
        toadDie = GameObject.FindGameObjectWithTag("Toad").GetComponent<ToadDie>();
        animation = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Toad"))
        {
            toadDie.UpdateCheckPoint(respawnPosition.position);
            animation.SetBool("ActiveCheckPoint", true);
        }
    }
}
