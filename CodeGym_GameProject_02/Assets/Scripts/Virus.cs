using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Virus : MonoBehaviour
{
    public VirusData virusData;
   
    private float startSpeed;
    private float currentHP;
    private float speed;
    public float VirusUpdateSpeed
    {
        get => speed;
        set => speed = value;
    }
    private int damaged;
    private int value;

   

    public bool isDead => currentHP <= 0;
    private void Awake()
    {
        

        VirusManager.instance.AddVirus(gameObject);

        currentHP = virusData.maxHp;
        startSpeed = virusData.speed;
        damaged = virusData.damaged;
        value = virusData.value;
    }
    // Start is called before the first frame update
    void Start()
    {

       speed = startSpeed;
            
    }

    public void Slow(float SlowAmount)
    {
        speed = startSpeed * (1 -  SlowAmount);
       
    }

    public void TakeDamage( float bulletDamage)
    {
        currentHP -= bulletDamage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        PlayerStats.money += value;
        Destroy(gameObject);
        Debug.Log("Virus Destroyed");
        if(VirusManager.instance != null)
        {
            VirusManager.instance.DeleteVirus(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
