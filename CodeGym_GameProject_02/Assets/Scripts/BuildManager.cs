using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    //private DefenderBluePrint defender01;

    private Defender01SO defender01;


    private void Awake()
    {
        instance = this;
    }


    //public bool Canbuild { get { return defender01 != null; } }
    public bool Canbuild { get { return defender01 != null; } }

    public bool IsEnoughMoney => PlayerStats.money >= defender01.cost;

    public void BuildDefenderOn(DefenderSlot slot)
    {
        if (PlayerStats.money < defender01.cost)
        {

            Debug.Log("Not enough money");
            return;

        }

        PlayerStats.money -= defender01.cost;

        GameObject defender = (GameObject)Instantiate(defender01.Prefab, slot.GetBuildPosition(), slot.GetBuildRotation());
        slot.defender = defender;

        Debug.Log("Money Left :" + PlayerStats.money);
    }
    public void SelectDefenderToBuild(Defender01SO defender)
    {
        defender01 = defender;
    }




}
