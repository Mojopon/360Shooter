using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
    public Projectile projectile;
    public float projectileSpeed = 10f;

    public void Shoot()
    {
        var newProjectile = Instantiate(projectile, transform.position, transform.rotation) as Projectile;
        newProjectile.SetSpeed(projectileSpeed);
    }   
}
