using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop Instance;
    BuildManager buildManager;
    //public DefenderBluePrint defender01;

    //private GameObject defenderPrefabs;

    //public Defender01SO defender01;

    public DefenderData defender01;
    public DefenderData defender02;
    public DefenderData defender03;

    
    // Start is called before the first frame update
    void Start()
    {
       buildManager = BuildManager.instance;
    }

    public void SelectDefender01()
    {
        Debug.Log("Buy Defender 01");
        //defenderPrefabs = defender01.Prefab;
        buildManager.SelectDefenderToBuild(defender01);
    }

    public void SelectDefender02()
    {
        Debug.Log("Buy Defender 02");
        buildManager.SelectDefenderToBuild(defender02);
        
    }

    public void SelectDefender03()
    {
        Debug.Log("Buy Defender 03");
        buildManager.SelectDefenderToBuild(defender03);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
