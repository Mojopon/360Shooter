using UnityEngine;
using System.Collections;

public class ChargeShotProjectile : Projectile
{
    public Transform secondBullet;
    public int numberToSpreadSecondBullets = 10;

    protected override void DealDamage(Collider2D collider, IDamageable damageable)
    {
        base.DealDamage(collider, damageable);
        if(damageable.IsDead())
        {
            Instantiate(secondBullet, collider.transform.position, Quaternion.identity);
        }
    }
}
