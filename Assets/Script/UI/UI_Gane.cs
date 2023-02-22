using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Gane : MonoBehaviour
{
    public Image hpGuage;
    public Text enemyNum;
    public GameObject pausePanel;

    void Start()
    {
        SoundManager.instance.Play("MainGame");
    }

    void Update()
    {
        hpGuage.fillAmount = GameManager.Instance.playerHP / 100;
        enemyNum.text = "Enemy remain: " + GameManager.Instance.enemyNum;
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            Screen.lockCursor = false;
            pausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void Resume()
    {
        SoundManager.instance.Play("Button");
        Time.timeScale = 1.0f;
        Screen.lockCursor = true;
        pausePanel.SetActive(false);
    }
}
