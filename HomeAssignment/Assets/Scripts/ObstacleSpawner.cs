using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //a list of WaveConfigs
    [SerializeField] List<WaveConfig> waveConfigs;

    //we always start from wave 0
    int startWave = 0;
    [SerializeField] bool looping = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllObstacles(WaveConfig waveConfig)
    {
        //spawn an emeny until obstacleCount is equal to getNumberOfObstacles()
        for(int obstacleCount = 0; obstacleCount <waveConfig.GetNumberOfObstacles(); obstacleCount++)
        { 
            //spawn the obstacles from waveConfig
            //at the position specifies by the waveConfig waypoints
             var newObstacle =Instantiate(
                waveConfig.GetObstaclePrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            //the wave will be selected from here and the obstacle applied to it
            newObstacle.GetComponent<ObstaclePathing>().SetWaveConfig(waveConfig);
         
        yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        //this will loop from startingWave until we reach the last within our list
        for(int waveIndex = startWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex]; 
            //the coroutine will wait for all enemies in Wave to spawn 
            //before yielding adn going to the next loop
            yield return StartCoroutine(SpawnAllObstacles(currentWave));
        }
    }
}
