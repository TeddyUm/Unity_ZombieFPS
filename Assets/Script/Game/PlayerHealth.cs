using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float hitPoints = 100.0f;

    private void Start()
    {
        hitPoints = GameManager.Instance.playerHP;
    }
    private void Update()
    {
        GameManager.Instance.playerHP = hitPoints;
        
        if (GameManager.Instance.enemyNum < 1)
        {
            GameManager.Instance.isWin = true;
            SoundManager.instance.Stop("MainGame");
            GameManager.Instance.ChangeScene("Result");
        }
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            GameManager.Instance.isWin = false;
            SoundManager.instance.Stop("MainGame");
            GameManager.Instance.ChangeScene("Result");
        }
    }
}