using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private PlayerHealth target;
    public float damage = 30.0f;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (target == null) return;
        else
        {
            SoundManager.instance.Play("ZAttack");
            target.GetComponent<DisplayDamage>().ShowDamageImpact();
            target.TakeDamage(damage);
        }
    }

    public void OnDamageTaken()
    {

    }
}
