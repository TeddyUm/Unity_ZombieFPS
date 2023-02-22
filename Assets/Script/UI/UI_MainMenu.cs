using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    public GameObject howtoPanel;
    public GameObject creditPanel;

    private void Start()
    {
        SoundManager.instance.Play("MainMenu");
    }
    public void StartButton()
    {
        SoundManager.instance.Stop("MainMenu");
        GameManager.Instance.ChangeScene("MainGame");
    }

    public void HowToButton()
    {
        SoundManager.instance.Play("Button");
        howtoPanel.SetActive(true);
    }

    public void CreditButton()
    {
        SoundManager.instance.Play("Button");
        creditPanel.SetActive(true);
    }

    public void CloseButton()
    {
        SoundManager.instance.Play("Button");
        creditPanel.SetActive(false);
        howtoPanel.SetActive(false);
    }
}
