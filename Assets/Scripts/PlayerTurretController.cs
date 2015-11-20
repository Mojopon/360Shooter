using UnityEngine;
using System.Collections;

public class PlayerTurretController : MonoBehaviour {

    public Turret turret;

	public void Shoot()
    {
        turret.Shoot();
    }
}
