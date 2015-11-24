using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PlayerController
{
    public float speed;
    public float turnSpeed = 180f;
    public float chargePerSec = 1f;

    private float currentChargeRate = 0;
    private IMovementController movementController;
    private IChargeShotController chargeShotController;

    public PlayerController() { }

    public void MoveForward(Quaternion rotation)
    {
        var movement = MovementHelper.GetStepFromSpeedAndRotation(speed, rotation);
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

        Debug.Log(currentChargeRate);
        chargeShotController.SetCurrentChargeRate(currentChargeRate);
    }

    public void ChargeShot()
    {
        if(currentChargeRate >= 1)
        {
            chargeShotController.ChargeShot();
        }
    }

    public void SetSpeed(float _speed)
    {
        speed = _speed;
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
