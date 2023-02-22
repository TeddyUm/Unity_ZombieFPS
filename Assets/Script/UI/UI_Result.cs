using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Result : MonoBehaviour
{
    public Text winText;
    public Image winImage;
    public Image failImage;

    private void Start()
    {
        Screen.lockCursor = false;
        if (GameManager.Instance.isWin)
        {
            SoundManager.instance.Play("Result");
            winImage.enabled = true;
            failImage.enabled = false;
        }
        else
        {
            SoundManager.instance.Play("GameOver");
            winImage.enabled = false;
            failImage.enabled = true;
        }
    }

    void Update()
    {
        if(GameManager.Instance.isWin)
        {
            winText.enabled = true;
        }
        else
        {
            winText.enabled = false;
        }
    }

    public void MainButton()
    {
        if (GameManager.Instance.isWin)
            SoundManager.instance.Stop("Result");
        else
            SoundManager.instance.Stop("GameOver");

        GameManager.Instance.playerHP = 100;
        GameManager.Instance.gunPower = 1;
        GameManager.Instance.enemySpeed = 1;
        GameManager.Instance.isWin = false;
        GameManager.Instance.isSlow = false;
        GameManager.Instance.isPower = false;
        GameManager.Instance.enemyNum = 6;

    GameManager.Instance.ChangeScene("MainMenu");
    }

    public void QuitButton()
    {
        SoundManager.instance.Play("Button");
        Application.Quit();
    }
}
