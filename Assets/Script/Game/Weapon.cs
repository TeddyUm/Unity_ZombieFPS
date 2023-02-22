using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Weapon : MonoBehaviour
{
    public Camera FPSCamera;
    public float range = 100.0f;
    public float damage = 30.0f;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;
    public Ammo ammoSlot;
    public AmmoType ammoType;
    public float timeBetweenShots;
    public Text ammoText;

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }
    void Update()
    {
        DisplayAmmo();
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        if (ammoType == AmmoType.ARBullet)
            SoundManager.instance.Play("AK");
        else if (ammoType == AmmoType.PistolBullet)
            SoundManager.instance.Play("Pistol");
        else if (ammoType == AmmoType.RifleBullet)
            SoundManager.instance.Play("Rifle");
        else if (ammoType == AmmoType.ShotgunBullet)
            SoundManager.instance.Play("Shotgun");

        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            ProcessRaycast();
            PlayMuzzleFlash();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }
    void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        if(ammoType == AmmoType.ARBullet)
            ammoText.text = "AK Ammo: " + currentAmmo.ToString();
        else if (ammoType == AmmoType.PistolBullet)
            ammoText.text = "HG Ammo: " + currentAmmo.ToString();
        else if(ammoType == AmmoType.RifleBullet)
            ammoText.text = "RF Ammo: " + currentAmmo.ToString();
        else if(ammoType == AmmoType.ShotgunBullet)
            ammoText.text = "SG Ammo: " + currentAmmo.ToString();
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPSCamera.transform.position, FPSCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null)
                return;

            if (GameManager.Instance.isPower)
                target.TakeDamage(damage * 1.5f);
            else
                target.TakeDamage(damage);

            Debug.Log("is hit");
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }

}
