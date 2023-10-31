using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TigerManagement : MonoBehaviour
{
    GameObject Toad;
    GameObject Tiger;
    Animator TigerAnimation;
    Rigidbody2D ToadRigidbody2D;
    void Start()
    {
        Toad = GameObject.FindGameObjectWithTag("Toad");
        Tiger = this.gameObject;
        TigerAnimation = GetComponent<Animator>();
        ToadRigidbody2D = Toad.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Toad"))
        {
            StartCoroutine(CountTigerChilds());
        }
    }

    private IEnumerator CountTigerChilds()
    {
        TigerAnimation.SetTrigger("destroy");
        yield return new WaitForSeconds(0.1f);
        Destroy(this.GameObject());
    }
}
