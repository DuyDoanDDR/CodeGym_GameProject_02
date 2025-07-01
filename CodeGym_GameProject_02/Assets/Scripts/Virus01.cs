using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Virus01 : MonoBehaviour
{
    public Virus01SO virus01Data;
    //public  static Virus01 instance;
    private int currentHP;
    private float speed;
    private int damaged;
    private int value;
   

    public bool isDead => currentHP <= 0;
    // Start is called before the first frame update
    void Start()
    {
        //instance = this;
        currentHP = virus01Data.maxHp;
        speed = virus01Data.speed;
        damaged = virus01Data.damaged;
        value = virus01Data.value;
       
    }

    public void TakeDamage( int bulletDamage)
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
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
