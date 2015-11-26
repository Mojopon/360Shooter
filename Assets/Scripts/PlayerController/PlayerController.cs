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

    private float currentSpeedRate = 0;
    private float currentChargeRate = 0;
    private IMovementControler movementController;
    private IChargeShotController chargeShotController;

    public PlayerController() { }

    public void Initialize()
    {
        SetSpeedFromCurrentGear();
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

    public void SetSpeedFromCurrentGear()
    {
        movementController.SetSpeed(gears[currentGear]);
    }

    public void Accelerate()
    {
        currentGear++;
        if(currentGear >= gears.Length)
        {
            currentGear = gears.Length - 1;
            return;
        }

        SetSpeedFromCurrentGear();
    }

    public void Decelerate()
    {
        currentGear--;
        if (currentGear < 0)
        {
            currentGear = 0;
            return;
        }

        SetSpeedFromCurrentGear();
    }

    public float GetCurrentSpeedRate()
    {
        return 1f / (gears.Length - currentGear);
    }

    public void SetMovementController(IMovementControler _movementController)
    {
        movementController = _movementController;
    }

    public void SetChargeShotController(IChargeShotController _chargeShotController)
    {
        chargeShotController = _chargeShotController;
    }
}
