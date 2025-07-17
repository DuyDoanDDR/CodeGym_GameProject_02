using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    

    private DefenderData builtDefender;

  

    private void Awake()
    {
        instance = this;
    }


    public bool Canbuild { get { return builtDefender != null; } }

    public bool IsEnoughMoney => PlayerStats.money >= builtDefender.cost;

    public void BuildDefenderOn(DefenderSlot slot)
    {
        if (PlayerStats.money < builtDefender.cost)
        {

            Debug.Log("Not enough money");
            return;

        }

        PlayerStats.money -= builtDefender.cost;

        GameObject defender = (GameObject)Instantiate(builtDefender.Prefab, slot.GetBuildPosition(), slot.GetBuildRotation());
        slot.defender = defender;

        Debug.Log("Money Left :" + PlayerStats.money);
    }
    public void SelectDefenderToBuild(DefenderData defenderPrefabs)
    {
        builtDefender = defenderPrefabs;
    }




}
