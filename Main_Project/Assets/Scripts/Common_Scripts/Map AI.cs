using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MapAI : MonoBehaviour
{
    public List<Transform> points;
    public int nextID = 0;
    int idChangeValue = 1;
    public float speed;


    //private void Update()
    //{
    //    MoveToNextPoint();
    //}

    //void MoveToNextPoint()
    //{
    //    //Get the next Point transform
    //    Transform goalPoint = points[nextID];
    //    //Flip the enemy transform to look into the point's direction
    //    if (goalPoint.transform.position.x > transform.position.x)
    //        transform.localScale = new Vector3(-1, 1, 1);
    //    else
    //        transform.localScale = new Vector3(1, 1, 1);
    //    //Move the enemy towards the goal point
    //    transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
    //    //Check vịt trí của enemies giữa goalPoint và nextID
    //    if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
    //    {
    //        //Check vị trí cuối (thay đổi idChangeValue -1)
    //        if (nextID == points.Count - 1)
    //            idChangeValue = -1;
    //        //Check vị trí xuất phát (thay đổi idChangeValue +1)
    //        if (nextID == 0)
    //            idChangeValue = 1;
    //        //Áp dụng thay đổi cho vị trí
    //        nextID += idChangeValue;
    //    }
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        FindObjectOfType<LifeCount>().LoseLife();
    //    }
    //}
}