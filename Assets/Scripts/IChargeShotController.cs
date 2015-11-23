using UnityEngine;
using System.Collections;

public interface IChargeShotController
{
    void Charging();
    void ChargeShot();
    void SetCurrentChargeRate(float chargeRate);
    float GetCurrentChargeRate();
}
