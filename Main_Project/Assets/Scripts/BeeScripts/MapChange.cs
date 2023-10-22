using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChange : MonoBehaviour
{
    private GameObject Player;
    private new Rigidbody2D rigidbody2D;
    [SerializeField] private BeeManagement Bee;
    [SerializeField] private ToadDie Toad;
    [SerializeField] private Transform SpawnMapPosition;
    [SerializeField] private Animator TransitionMapAnimation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Toad") || collision.gameObject.CompareTag("Bee"))
        {
            rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
            Player = collision.gameObject;
            Bee.UpdateStartPosition(SpawnMapPosition.position);
            Toad.UpdateCheckPoint(SpawnMapPosition.position);
            StartCoroutine(TransitionMap(1.0f));
        }
    }

    private IEnumerator TransitionMap(float duration)
    {
        rigidbody2D.simulated = false;
        TransitionMapAnimation.Play("TransitionEnd");
        yield return new WaitForSeconds(duration);
        Player.transform.position = SpawnMapPosition.position;
        TransitionMapAnimation.Play("TransitionStart");
        yield return new WaitForSeconds(duration);
        rigidbody2D.simulated = true;
    }
}
