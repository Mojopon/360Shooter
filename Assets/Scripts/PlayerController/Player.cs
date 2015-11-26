using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerTurretController))]
public class Player : MonoBehaviour, IFieldEntity, IMovementController, IChargeShotController
{
    public PlayerController controller;

    public Transform boostParticle;

    private float currentSpeed;
    private float currentChargeRate;

    private float previousVerticalInput;

    private Rigidbody2D myRigidbody;
    private PlayerTurretController turret;
    

    void OnEnable()
    {
        controller.SetMovementController(this);
        controller.SetChargeShotController(this);
        controller.Initialize();

        myRigidbody = GetComponent<Rigidbody2D>();
        turret = GetComponent<PlayerTurretController>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("Vertical") == 0) ReceiveNextVerticalInput();

        if(IsAccelerating())
        {
            var previousSpeed = currentSpeed;
            controller.Accelerate();
            if (previousSpeed != currentSpeed)
            {
                var newParticle = Instantiate(boostParticle, transform.position, transform.rotation) as Transform;
                newParticle.SetParent(transform);
            }
        }
        else if(IsDecelerating())
        {
            controller.Decelerate();
        }

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

    void Move(Vector3 movement)
    {
        myRigidbody.MovePosition(transform.position + (movement * Time.fixedDeltaTime));
    }

    #region IMovementController Method Group

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Rotate(float turning)
    {
        // turn the ship
        Quaternion rotation = transform.rotation;
        float z = rotation.eulerAngles.z;
        z += turning * Time.fixedDeltaTime;
        myRigidbody.MoveRotation(z);
    }

    #endregion

    void FixedUpdate()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        controller.Rotate(horizontalInput);

        var movement = MovementHelper.GetMovementToForward(currentSpeed, transform.rotation);
        Move(movement);
    }

    bool IsShooting()
    {
        return Input.GetKey(KeyCode.Z);
    }

    bool isCharging()
    {
        return Input.GetKey(KeyCode.X);
    }

    void ReceiveNextVerticalInput()
    {
        previousVerticalInput = 0;
    }

    bool IsAccelerating()
    {
        var verticalInput = Input.GetAxisRaw("Vertical");
        if(previousVerticalInput == 0 && verticalInput == 1)
        {
            previousVerticalInput = verticalInput;
            return true;
        }

        return false;
    }

    bool IsDecelerating()
    {
        var verticalInput = Input.GetAxisRaw("Vertical");
        if (previousVerticalInput == 0 && verticalInput == -1)
        {
            previousVerticalInput = verticalInput;
            return true;
        }

        return false;
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
