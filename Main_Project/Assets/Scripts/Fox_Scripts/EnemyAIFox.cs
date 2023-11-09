using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class EnemyAIFox : MonoBehaviour
{
    public AIPath aiPath;

    // Update is called once per frame


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            // Handle enemy death here
            Die();
        }
        
    }
    private void Die()
    {
        // Disable pathfinding to stop enemy movement
        aiPath.enabled = false;

        // Perform death animation or effects if needed
        // For example, you can play an explosion animation or sound

        // Disable the enemy's game object or remove it from the scene
        gameObject.SetActive(false);

        // Check win state or update game logic
        FindObjectOfType<FoxGameManager>().CheckWinState();
    }
    void Update()
    {

        if (aiPath.desiredVelocity.x >= 0.01f)

        {

            transform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)

        {


            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }

       

    }
}
