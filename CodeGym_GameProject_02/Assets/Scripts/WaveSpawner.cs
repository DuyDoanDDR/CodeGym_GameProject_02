using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public VirusData virusData;
    public Transform Spawnpoint;
    public float countDownTime = 3f;
    public float timeBetweenWaves = 5f;
    public float spawnDelayTime = 0.1f;
    private int waveNumber = 0;
    //public TMPro.TextMeshProUGUI TimerText;
    public static WaveSpawner instance;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (countDownTime < 0.2f)
        {
            StartCoroutine(SpawnWaves());
            countDownTime = timeBetweenWaves;
        }
        countDownTime -= Time.deltaTime;
        countDownTime = Mathf.Clamp(countDownTime, 0f, Mathf.Infinity);
        
    }

    IEnumerator SpawnWaves()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnViruses();
            yield return new WaitForSeconds(spawnDelayTime);
        }

        Debug.Log("Wave is coming !");
    }
    void SpawnViruses()
    {
        Instantiate(virusData.virusPrefab, Spawnpoint.position, Quaternion.Euler(0, 90, 0));
    }
}
