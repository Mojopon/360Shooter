using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerTurretController))]
public class Player : MonoBehaviour, IFieldEntity, IMovementController
{
    public PlayerController controller;

    Rigidbody2D myRigidbody;
    PlayerTurretController turret;

    void OnEnable()
    {
        Debug.Log("on enable");
        controller.SetMovementController(this);

        myRigidbody = GetComponent<Rigidbody2D>();
        turret = GetComponent<PlayerTurretController>();
    }

    void Update()
    {
        if(IsShooting())
        {
            turret.Shoot();
        }
    }

    public void MoveForward(Vector3 movement)
    {
        myRigidbody.MovePosition(transform.position + (movement * Time.fixedDeltaTime));
    }

    public void Rotate(float turning)
    {
        // turn the ship
        Quaternion rotation = transform.rotation;
        float z = rotation.eulerAngles.z;
        z += turning * Time.fixedDeltaTime;
        myRigidbody.MoveRotation(z);
    }

    void FixedUpdate()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        controller.Rotate(horizontalInput);
        controller.MoveForward(transform.rotation);
    }

    bool IsShooting()
    {
        return Input.GetKey(KeyCode.Z);
    }

    #region IFieldEntity

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    #endregion
}
