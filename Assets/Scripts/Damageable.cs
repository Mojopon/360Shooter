using UnityEngine;
using System.Collections;
using System;

public class Damageable
{
    public Action OnDeath;

    private int health;
    private IDamageController controller;
    private bool dead;

    public Damageable(int startingHealth)
    {
        health = startingHealth;
    }

    public void TakeHit(int damage)
    {
        health -= damage;

        if (health <= 0 && !dead)
        {
            Die();
        }
    }

    public bool IsDead()
    {
        return dead;
    }

    private void Die()
    {
        dead = true;

        if (OnDeath != null) OnDeath();
        controller.Die();
    }

    public void SetDamageController(IDamageController damageController)
    {
        controller = damageController;
    }
}
