using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform virusPrefabs; 
    public Transform Spawnpoint;
    public float countDownTime = 3f;
    public float timeBetweenWaves = 5f;
    private int waveNumber = 1;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( countDownTime < 0.2f)
        {
            SpawnWaves();
            countDownTime = timeBetweenWaves;
        }
        countDownTime -= Time.deltaTime;
    }
     
    void SpawnWaves()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnViruses();
           
        }
        waveNumber++;
        Debug.Log("Wave is coming !");
    }
    void SpawnViruses()
    {
        Instantiate(virusPrefabs, Spawnpoint.position, Quaternion.Euler(0,90,0));
    }
}
