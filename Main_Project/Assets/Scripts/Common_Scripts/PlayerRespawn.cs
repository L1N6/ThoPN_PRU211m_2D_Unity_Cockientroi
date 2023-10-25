using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 respawnPoint;

    private void RespawnNow()
    {
        transform.position = respawnPoint;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Death"))
        {
            RespawnNow();
        }
    }
}
