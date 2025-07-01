using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private DefenderBluePrint defenderToBuild;


    private void Awake()
    {
        instance = this;
    }


    public bool Canbuild { get { return defenderToBuild != null; } }
    public bool IsEnoughMoney => PlayerStats.money >= defenderToBuild.cost;

    public void BuildDefenderOn(DefenderSlot slot)
    {
        if (PlayerStats.money < defenderToBuild.cost)
        {

            Debug.Log("Not enough money");
            return;

        }

        PlayerStats.money -= defenderToBuild.cost;

        GameObject defender = (GameObject)Instantiate(defenderToBuild.defenderPrefab, slot.GetBuildPosition(), slot.GetBuildRotation());
        slot.defender = defender;

        Debug.Log("Money Left :" + PlayerStats.money);
    }
    public void SelectDefenderToBuild(DefenderBluePrint defender)
    {
        defenderToBuild = defender;
    }




}
