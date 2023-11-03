using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChange : MonoBehaviour
{
    private bool isEnd;
    private GameObject Player;
    private new Rigidbody2D rigidbody2D;
    [SerializeField] private int flowerCondition;
    [SerializeField] private BeeManagement Bee;
    [SerializeField] private ToadDie Toad;
    [SerializeField] private Transform SpawnMapPosition;
    [SerializeField] private Animator TransitionMapAnimation;
    [SerializeField] SwitchPlayer switchPlayerBee;
    [SerializeField] SwitchPlayer switchPlayerToad;
    [SerializeField] AudioManager audioManager;

    private void Start()
    {
        isEnd = false;
    }
    public void UpdateEnd()
    {
        isEnd = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerPrefs.GetInt("FlowerCount") == flowerCondition)
        {
            if (collision.gameObject.CompareTag("Toad") || (collision.gameObject.CompareTag("Bee") && !isEnd))
            {
                rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
                Player = collision.gameObject;
                Bee.UpdateStartPosition(SpawnMapPosition.position);
                Toad.UpdateCheckPoint(SpawnMapPosition.position);
                if (isEnd)
                {
                    switchPlayerBee.UpdateLockKeyCode();
                    switchPlayerToad.UpdateLockKeyCode();
                }
                StartCoroutine(TransitionMap(1.0f));
            }
        }
    }

    private IEnumerator TransitionMap(float duration)
    {
        rigidbody2D.simulated = false;
        TransitionMapAnimation.Play("TransitionEnd");
        audioManager.PlaySFX(audioManager.PortalIn);
        yield return new WaitForSeconds(duration);
        Player.transform.position = SpawnMapPosition.position;
        TransitionMapAnimation.Play("TransitionStart");
        audioManager.PlaySFX(audioManager.PortalOut);
        yield return new WaitForSeconds(duration);
        rigidbody2D.simulated = true;
    }
}
