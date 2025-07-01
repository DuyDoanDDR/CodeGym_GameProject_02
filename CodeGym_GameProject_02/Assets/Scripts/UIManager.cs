using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI waveTimer;
    public TMPro.TextMeshProUGUI money;
    public TMPro.TextMeshProUGUI HP;
    WaveSpawner waveSpawner;

   
    // Start is called before the first frame update
    void Start()
    {
        waveSpawner = WaveSpawner.instance;
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
    // Update is called once per frame
    void Update()
    {
        WaveTimerUI();
        MoneyUI();
        HPUI();
    }
}

