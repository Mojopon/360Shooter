using UnityEngine;
using System.Collections;

public interface IMovementControler
{
    void SetSpeed(float speed);
    void Rotate(float turning);
    float GetCurrentSpeedRate();
}
