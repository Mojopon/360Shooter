using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
    public Transform projectile;
    public float projectileSpeed = 10f;
    public float msBetweenShot = 100f;

    private float nextShot;

    public void Shoot()
    {
        if (Time.time > nextShot)
        {
            var newProjectile = Instantiate(projectile, transform.position, transform.rotation) as Transform;
            newProjectile.GetComponent<IProjectile>().SetSpeed(projectileSpeed);
            nextShot = Time.time + msBetweenShot / 1000;
        }
    }   
}
