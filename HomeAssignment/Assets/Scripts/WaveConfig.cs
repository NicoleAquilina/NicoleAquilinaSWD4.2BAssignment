using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Obstacle Wave Config")]
public class WaveConfig : ScriptableObject
{

    //the enemy
    [SerializeField] GameObject obstaclePrefab;
    //the path on which to go
    [SerializeField] GameObject pathPrefab;
    //time between each spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;
    //include this random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;
    //number of enemies in the wave
    [SerializeField] int numberOfObstacles = 3;
    //enemy movement speed
    [SerializeField] float obstacleMoveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetObstaclePrefab()
    {
        return obstaclePrefab;
    }

    public List<Transform>GetWaypoints()
    {
        //eachh wave can have different waypoints
        var waveWaypoints = new List<Transform>();
        //go into the path prefab , and for each child ass it to the list
        foreach(Transform child in pathPrefab.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float GetObstacleMoveSpeed()
    {
        return obstacleMoveSpeed;
    }

}
