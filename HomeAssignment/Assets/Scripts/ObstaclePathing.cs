using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] WaveConfig waveConfig;
    int waypointIndex = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        obstacleMove();
    }
    private void obstacleMove()
    {
        if(waypointIndex <= waypoints.Count -1)
        {
            //save the current waypoint in targetPosition
            var targetPosition = waypoints[waypointIndex].transform.position;
            //to make sure z position is 0
            targetPosition.z = 0f;
            var movement = waveConfig.GetObstacleMoveSpeed()* Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movement);

            //if we reached the trget waypoint
            if(transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
    }
    public void SetWaveConfig (WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
