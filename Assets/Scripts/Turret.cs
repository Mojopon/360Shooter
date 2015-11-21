using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
    public Projectile projectile;
    public float projectileSpeed = 10f;
    public float msBetweenShot = 100f;

    private float nextShot;

    public void Shoot()
    {
        if (Time.time > nextShot)
        {
            var newProjectile = Instantiate(projectile, transform.position, transform.rotation) as Projectile;
            newProjectile.SetSpeed(projectileSpeed);
            nextShot = Time.time + msBetweenShot / 1000;
        }
    }   
}
