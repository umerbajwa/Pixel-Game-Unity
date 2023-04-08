using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoints : MonoBehaviour
{
    public Transform[] Waypoints;

    public int currentWayPointIndex;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(Waypoints[currentWayPointIndex].position,transform.position) < 0.1f)
        {
            currentWayPointIndex++;
            if (currentWayPointIndex >= Waypoints.Length)
            {
                currentWayPointIndex = 0;
            }
        }
       transform.position =  Vector2.MoveTowards(transform.position, Waypoints[currentWayPointIndex].position, Time.deltaTime * speed);
        
    }
}
