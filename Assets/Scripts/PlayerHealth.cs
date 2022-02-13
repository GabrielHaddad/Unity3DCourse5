using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DeathHandler))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    DeathHandler deathHandler;

    void Awake() 
    {
        deathHandler = GetComponent<DeathHandler>();
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        deathHandler.HandleDeath();
        // Destroy(gameObject);
        Debug.Log("Died");
    }
}
