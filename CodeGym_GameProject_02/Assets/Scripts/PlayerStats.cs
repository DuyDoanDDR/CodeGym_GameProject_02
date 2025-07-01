using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int lives;
    public int startLives = 1;

    public static int money;
    public int startMoney = 50;

    // Start is called before the first frame update
    void Start()
    {
        money = startMoney;
        lives = startLives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
