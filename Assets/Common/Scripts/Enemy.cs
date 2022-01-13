using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    int currentWaypoint = 0;
    private float lastWaypointSwitchTime;
    [SerializeField] float speed = 1.0f;
    public GameObject auto;
    
    
    // Start is called before the first frame update
    void Start()
    {
        lastWaypointSwitchTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;

        float pathLength = Vector3.Distance(startPosition, endPosition);
        float totalTimeForPath = pathLength / speed;
        float currentTimeOnPath = Time.time - lastWaypointSwitchTime;
        
        transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.Clamp(currentTimeOnPath/totalTimeForPath,0f,1f));


        if (auto.transform.position.Equals(endPosition))
        {
            if (currentWaypoint < waypoints.Length-2)
            {
                currentWaypoint++;
                
                lastWaypointSwitchTime = Time.time;
                RotateEnemy();
            }else
        {
                CameraShake.instance.StartShake();
GameManager.singleton.DeIncreaseHealth(-1);
            Destroy(gameObject);
            
        }
        }
        
        
        
    }

    public float DistanceToGoal()
    {
        float distance = 0f;
        distance += Vector2.Distance(gameObject.transform.position, waypoints[currentWaypoint+1].transform.position);

        for (int i = currentWaypoint + 1; i < waypoints.Length - 1; i++)
        {
            Vector3 startPosition = waypoints[i].transform.position;
            Vector3 endPosition = waypoints[i + 1].transform.position;
            distance = distance + Vector2.Distance(startPosition, endPosition);
        }
        
        return distance;
    }

    private void RotateEnemy()
    {
        Vector3 startPosition = waypoints[currentWaypoint].transform.position;
        Vector3 endPosition = waypoints[currentWaypoint + 1].transform.position;

        Vector3 newDirection = (startPosition - endPosition);

        float x = newDirection.x;
        float y = newDirection.y;
        float rotationAngle = Mathf.Atan2(y, x) * -180 / Mathf.PI;

        auto.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);

        
    }
}
