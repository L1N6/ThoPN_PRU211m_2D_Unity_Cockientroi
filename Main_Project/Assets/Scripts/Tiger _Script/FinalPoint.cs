using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPoint : MonoBehaviour
{
    GameObject player;
    new Animator animation;
    new Rigidbody2D rigidbody2D;
    ToadDie toadDie;
    Vector2 checkPointPosition;
    public Transform destination;
    private GameManagement gameManagement = new GameManagement();

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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
        if (collision.CompareTag("Toad") && Vector2.Distance(player.transform.position, transform.position) > 0.5f)
        {
            StartCoroutine(PortalIn());
        }
    }

    IEnumerator PortalIn()
    {
        gameManagement.UpdateAnimalWinStatus(GameManagement.Animal.Tiger.ToString());
        rigidbody2D.simulated = false;
        animation.Play("Portal_In");
        audioManager.PlaySFX(audioManager.PortalIn);
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Common_Scenes");
    }
}
