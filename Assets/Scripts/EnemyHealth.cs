using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    bool isDead = false;

    public bool IsDead()
    {
        return isDead;
    }
    // create public method which reduses hitpoints by the amount of damage
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            // Destroy(gameObject);
            Die();
        }
    }

    void Die()
    {
        if (isDead)
        {
            return;
        }
        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }

}
