using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
   
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float distance = .1f;
    private int currentWayPointIndex = 0;
    [SerializeField] private float speed = 2f;
    // Start is called before the first frame update

  
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWayPointIndex].transform.position,transform.position)<distance)
        {
            currentWayPointIndex++;
            if (currentWayPointIndex>=waypoints.Length)
            {
                currentWayPointIndex = 0;
            }
            
        }
        transform.position=Vector2.MoveTowards(transform.position, waypoints[currentWayPointIndex].transform.position,Time.deltaTime* speed);
    }
}
