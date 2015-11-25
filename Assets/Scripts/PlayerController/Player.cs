using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerTurretController))]
public class Player : MonoBehaviour, IFieldEntity, IMovementController, IChargeShotController
{
    public PlayerController controller;

    private float currentChargeRate;

    private Rigidbody2D myRigidbody;
    private PlayerTurretController turret;
    

    void OnEnable()
    {
        Debug.Log("on enable");
        controller.SetMovementController(this);
        controller.SetChargeShotController(this);
        controller.Initialize();

        myRigidbody = GetComponent<Rigidbody2D>();
        turret = GetComponent<PlayerTurretController>();
    }

    void Update()
    {
        if(IsShooting())
        {
            turret.Shoot();
        }

        if(Input.GetKeyUp(KeyCode.X))
        {
            controller.ChargeShot();
        }
        controller.Charge(isCharging(), Time.deltaTime);
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

    bool isCharging()
    {
        return Input.GetKey(KeyCode.X);
    }

    public void Charging()
    {
    }

    public void ChargeShot()
    {
        turret.ChargeShot();
    }

    public void SetCurrentChargeRate(float chargeRate)
    {
        currentChargeRate = chargeRate;
    }

    public float GetCurrentChargeRate()
    {
        return currentChargeRate;
    }

    #region IFieldEntity
    public Vector3 GetPosition()
    {
        return transform.position;
    }
    #endregion
}
