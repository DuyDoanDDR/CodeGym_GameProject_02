using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop Instance;
    BuildManager buildManager;
    public DefenderBluePrint defender01;
    
    // Start is called before the first frame update
    void Start()
    {
       buildManager = BuildManager.instance;
    }

    public void SelectDefender01()
    {
        Debug.Log("Buy Defender 01");
        buildManager.SelectDefenderToBuild(defender01);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
