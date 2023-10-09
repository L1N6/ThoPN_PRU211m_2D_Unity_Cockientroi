using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    private PlayerRespawn playerRespawn;
    public GameObject greenFlag;
    public GameObject redFlag;
    private void Start()
    {
        playerRespawn = GameObject.Find("Player").GetComponent<PlayerRespawn>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerRespawn.respawnPoint = transform.position;
            greenFlag.SetActive(true);
            redFlag.SetActive(false);
        }
    }

}
