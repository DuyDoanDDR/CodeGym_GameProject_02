using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI waveTimer;
    public TMPro.TextMeshProUGUI money;
    public TMPro.TextMeshProUGUI HP;
    public GameObject gameOverUI;
    public GameObject gameWinUI;
    public GameObject restartButton;
    public GameObject quitButton;

    public static UIManager instance;

    WaveSpawner waveSpawner;

    GameManager gameManager;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        waveSpawner = WaveSpawner.instance;
       gameManager = GameManager.instance;
    }

    public void WaveTimerUI()
    {
        int timeSeconds = Mathf.FloorToInt(waveSpawner.countDownTime);
        waveTimer.text = string.Format("Next Wave: {0}", timeSeconds.ToString());
    }

    public void MoneyUI()
    {
        money.text = string.Format("$: " + PlayerStats.money.ToString());
    }

    public void HPUI()
    {
        HP.text = string.Format("HP: " + PlayerStats.lives);
    }


    public void GameStatementUI(GameObject statementUI)
    {
        if (statementUI == null)
        {
            Debug.LogError("statementUI  null");
            return;
        }
        statementUI.SetActive(true);       
    }
    public void GameOverUI()
    {
        GameStatementUI(gameOverUI);
    }
    public void GameWinUI()
    {
        GameStatementUI(gameWinUI);
    }
    public void RestartButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //if (gameManager.gameIsStopped)
        //{
        //    GameManager.gameWin = false;
        //    GameManager.gameOver = false;
        //}

    }
    public void QuitButton()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        WaveTimerUI();
        MoneyUI();
        HPUI();
    }
}

