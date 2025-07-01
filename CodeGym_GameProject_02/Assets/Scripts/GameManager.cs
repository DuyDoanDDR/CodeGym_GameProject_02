using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    //public GameObject gameOverUI;
    

    public float gameTime;
    public static bool gameWin;


    public bool gameIsStopped => gameOver || gameWin;

    public static GameManager instance;
   
   


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameWin = false;
        
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver || gameWin)
        {
            return;
        }
        if (PlayerStats.lives <= 0)
        {
            
            GameStatement( gameOver, UIManager.instance.gameOverUI);
        }
        else
        {
            gameTime -= Time.deltaTime;
            if (gameTime <= 0)
            {
                GameStatement( gameWin, UIManager.instance.gameWinUI);
            }
        }
    }


    void GameStatement( bool gameStatement, GameObject statementUI)
    {
        gameStatement = true;
        
        UIManager.instance.GameStatementUI(statementUI);
        
        Time.timeScale = 0.0f;
    }
   
}
