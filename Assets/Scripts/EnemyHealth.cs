using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;
    public bool IsDead => isDead;

    public void TakeDamage(float damage)
    {
        NotifyEnemy();
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;
        
        isDead = true;
        GetComponent<Animator>().SetTrigger("Die");
        //Destroy(gameObject);
    }

    void NotifyEnemy()
    {
        BroadcastMessage("OnDamageTaken");
    }

}
