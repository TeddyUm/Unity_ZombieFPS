using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickUp : MonoBehaviour
{
    public float restoreAngle = 90.0f;
    public float addIntensity = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SoundManager.instance.Play("Item");
            other.GetComponentInChildren<FlashLight>().RestoreLightAngle(restoreAngle);
            other.GetComponentInChildren<FlashLight>().RestoreLightIntensity(addIntensity);
            Destroy(gameObject);
        }
    }
}
