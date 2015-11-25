using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PlayerController
{
    public float turnSpeed = 180f;
    public float chargePerSec = 1f;

    public int currentGear = 1;
    public int[] gears = new int[] {
        3,
        5,
        7,
    };

    private float currentSpeed;
    private float currentChargeRate = 0;
    private IMovementController movementController;
    private IChargeShotController chargeShotController;

    public PlayerController()
    {
    }

    public void Initialize()
    {
        SetGear(currentGear);
    }

    public void MoveForward(Quaternion rotation)
    {
        var movement = MovementHelper.GetStepFromSpeedAndRotation(currentSpeed, rotation);
        movementController.MoveForward(movement);
    }

    public void Rotate(float input)
    {
        var turning = -input * turnSpeed;
        movementController.Rotate(turning);
    }

    public void Charge(bool isCharging, float timeStep)
    {
        switch(isCharging)
        {
            case true:
                {
                    currentChargeRate += chargePerSec * timeStep;
                    if(currentChargeRate > 1.0f)
                    {
                        currentChargeRate = 1;
                    }
                }
                break;
            case false:
                {
                    currentChargeRate -= 2f * timeStep;
                    if(currentChargeRate < 0)
                    {
                        currentChargeRate = 0;
                    }
                }
                break;
        }

        chargeShotController.SetCurrentChargeRate(currentChargeRate);
    }

    public void ChargeShot()
    {
        if(currentChargeRate >= 1)
        {
            chargeShotController.ChargeShot();
        }
    }

    public void SetGear(int gearNumber)
    {
        currentSpeed = gears[gearNumber];
    }

    public void Accelerate()
    {

    }

    public void Decelerate()
    {

    }

    public void SetMovementController(IMovementController _movementController)
    {
        movementController = _movementController;
    }

    public void SetChargeShotController(IChargeShotController _chargeShotController)
    {
        chargeShotController = _chargeShotController;
    }
}
