using UnityEngine;
using System.Collections;

public interface IMovementController
{
    void SetSpeed(float speed);
    void Rotate(float turning);
}
