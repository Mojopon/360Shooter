using UnityEngine;
using System.Collections;
using System;

public class DamageableEntity : MonoBehaviour, IDamageable, IDamageController
{
    public int health;
    public Action OnDeath
    {
        get { return damageable.OnDeath;}
        set { damageable.OnDeath = value; }

    }

    protected virtual void OnEnable()
    {
        damageable = new Damageable(health);
        damageable.SetDamageController(this);
    }

    private Damageable damageable;

    public void TakeHit(int damage)
    {
        damageable.TakeHit(damage);
    }

    public bool IsDead()
    {
        return damageable.IsDead();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
