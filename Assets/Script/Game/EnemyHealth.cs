using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float hitPoints = 100.0f;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            if (isDead)
                return;
            SoundManager.instance.Play("ZDie");
            GetComponent<Animator>().SetTrigger("Death");
            isDead = true;

            Destroy(gameObject, 2);
        }
    }
}
