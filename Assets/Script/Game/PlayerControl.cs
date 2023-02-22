using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public Text message;
    private Weapon weapon;
    private bool isTime;
    private float time;
    private PlayerHealth playerHealth;
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

    }

    void Update()
    {
        if(isTime)
        {
            message.enabled = true;
            time += Time.deltaTime;
            if(time > 3)
            {
                message.enabled = false;
                time = 0;
                isTime = false;
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Healing"))
        {
            SoundManager.instance.Play("Effect");
            message.text = "Healing Zone";
            isTime = true;
        }
        if (other.CompareTag("EnemySlow"))
        {
            message.text = "Press E: Enemy slow";
            isTime = true;
        }
        if (other.CompareTag("GunPower"))
        {
            message.text = "Press E: Gun power x 150%";
            isTime = true;
        }
        if (other.CompareTag("Item"))
        {
            if (GameManager.Instance.curWeapon == 0)
            {
                message.text = "AK ammo get";
                SoundManager.instance.Play("Item");
            }
            else if (GameManager.Instance.curWeapon == 1)
            {
                message.text = "Pistol ammo get";
                SoundManager.instance.Play("Item");
            }
            else if (GameManager.Instance.curWeapon == 2)
            {
                message.text = "Rifle ammo get";
                SoundManager.instance.Play("Item");
            }
            else if (GameManager.Instance.curWeapon == 3)
            {
                message.text = "Shotgun ammo get";
                SoundManager.instance.Play("Item");
            }

            isTime = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Healing"))
        {
            if (playerHealth.hitPoints > 100)
            {
                playerHealth.hitPoints = 100;
            }
            else
            {
                playerHealth.hitPoints += Time.deltaTime * 5;
            }
        }

        if(Input.GetKeyDown(KeyCode.E) && other.CompareTag("EnemySlow"))
        {
            if (!GameManager.Instance.isSlow)
            {
                SoundManager.instance.Play("Effect");
                message.text = "Enemy speed decreased";
                isTime = true;
            }
            GameManager.Instance.isSlow = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && other.CompareTag("GunPower"))
        {
            if (!GameManager.Instance.isPower)
            {
                SoundManager.instance.Play("Effect");
                message.text = "Gun is more powerful";
                isTime = true;
            }
            GameManager.Instance.isPower = true;
        }
    }
}
