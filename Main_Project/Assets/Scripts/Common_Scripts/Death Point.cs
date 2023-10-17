using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPoint : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> respamnPoints;
    private GameObject respamnPoint;
    public int size = 7;

    void Start()
    {
        respamnPoint = respamnPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < respamnPoints.Count; i++)
        {

            //if (player.transform.position > 0)
            //{
            if (player.transform.position.x >= respamnPoints[i].transform.position.x && player.transform.position.x <= respamnPoints[i + 1].transform.position.x)
            {
                respamnPoint = new GameObject();
                Debug.Log("i: = " + i + ", i + 1 = " + (i + 1));
                respamnPoint = respamnPoints[i];
                //Debug.Log(respamnPoint.transform.position);
                break;
            }
            //}
        }

        //respamnPoint.transform.position=player.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    player.transform.position = respamnPoint.transform.position;
        //}

    }
}
