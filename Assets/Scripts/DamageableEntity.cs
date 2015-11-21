using UnityEngine;
using System.Collections;
using System;

public class DamageableEntity : MonoBehaviour, IDamageable {

    public int startingHealth;
    protected int health;
    protected bool dead;

    protected virtual void Start()
    {
        health = startingHealth;
    }

    public void TakeHit(int damage)
    {
        TakeDamage(damage);
    }

    public bool IsDead()
    {
        return dead;
    }

    protected void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0 && !dead)
        {
            Die();
        }
    }

    protected void Die()
    {
        dead = true;
        Destroy(gameObject);
    }
}
