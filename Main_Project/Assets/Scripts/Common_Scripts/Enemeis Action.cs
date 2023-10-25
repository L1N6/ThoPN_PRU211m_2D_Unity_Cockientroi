using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour
{
    public List<Transform> points;
    public int nextID = 0;
    int idChangeValue = 1;
    public float speed;
    public string name;


    private void Reset()
    {
        Init();
    }

    void Init()
    {
        //Chọn box collider trigger
        GetComponent<BoxCollider2D>().isTrigger = true;

        //Tạo Root object
        GameObject root = new GameObject(name + "_Root");
        //Reset Position of Root to enemy object
        root.transform.position = transform.position;
        //Set enemy object as child of root
        transform.SetParent(root.transform);
        //Tạo object Waypoints
        GameObject waypoints = new GameObject("Waypoints");
        //Reset waypoints position to root        
        //Make waypoints object child of root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        //Create two points (gameobject) and reset their position to waypoints objects
        //Make the points children of waypoint object
        GameObject p1 = new GameObject("Point1");
        p1.transform.SetParent(waypoints.transform);
        p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2");
        p2.transform.SetParent(waypoints.transform);
        p2.transform.position = root.transform.position;

        //Add các point vào list
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }

    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //Get the next Point transform
        Transform goalPoint = points[nextID];
        //Flip the enemy transform to look into the point's direction
        if (name != "Map")
        {
            if (goalPoint.transform.position.x > transform.position.x)
                transform.localScale = new Vector3(-1, 1, 1);
            else
                transform.localScale = new Vector3(1, 1, 1);
        }
        //Move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //Check vịt trí của enemies giữa goalPoint và nextID
        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            //Check vị trí cuối (thay đổi idChangeValue -1)
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            //Check vị trí xuất phát (thay đổi idChangeValue +1)
            if (nextID == 0)
                idChangeValue = 1;
            //Áp dụng thay đổi cho vị trí
            nextID += idChangeValue;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        FindObjectOfType<LifeCount>().LoseLife();
    //    }
    //}
}