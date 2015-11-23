using UnityEngine;
using System.Collections;

public interface IMovementController
{
    void MoveForward(Vector3 movement);
    void Rotate(float turning);
}
