using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerTurretController))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;

    PlayerController controller;
    PlayerTurretController turret;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        controller.SetSpeed(moveSpeed);

        turret = GetComponent<PlayerTurretController>();
    }

    void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        controller.SetRotatingMovement(turnSpeed * horizontalInput);

        if(IsShooting())
        {
            turret.Shoot();
        }
    }

    bool IsShooting()
    {
        return Input.GetKey(KeyCode.Z);
    }
}
