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

            for(int i = 0; i < numberToSpreadSecondBullets; i++)
            {
                var transform = Instantiate(secondBullet, collider.transform.position, Quaternion.identity) as Transform;
                var angle = (360 / numberToSpreadSecondBullets) * i;
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.x, angle);
            }
        }
    }
}
