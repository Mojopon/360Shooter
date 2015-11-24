using UnityEngine;
using System.Collections;

public class PlayerTurretController : MonoBehaviour {

    public Turret turret;
    public Turret cannon;

	public void Shoot()
    {
        turret.Shoot();
    }

    public void ChargeShot()
    {
        cannon.Shoot();
    }
}
