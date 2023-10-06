using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPoint : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> respamnPoints;
    private GameObject respamnPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //respamnPoint.transform.position=player.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < respamnPoints.Count; i++)
            {
                if (respamnPoints[i].transform.position == player.transform.position)
                {
                    player.transform.position = respamnPoints[i].transform.position;
                    break;
                }
            }
        }

    }
}
