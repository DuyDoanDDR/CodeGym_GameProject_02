using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            return;
        }
        if (PlayerStats.lives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        gameOver = true;
        Debug.Log("GameOver");
        
    }
}
