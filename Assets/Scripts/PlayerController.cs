using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PlayerController
{
    public float speed;
    public float turnSpeed = 180f;

    private IMovementController movementController;

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

    public void SetSpeed(float _speed)
    {
        speed = _speed;
    }

    public void SetMovementController(IMovementController _movementController)
    {
        movementController = _movementController;
    }
}
