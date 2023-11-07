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
