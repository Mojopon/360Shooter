using UnityEngine;
using System.Collections;

public static class RotationHelper
{ 
    public static float GetAngleFromQuaternion(Quaternion rotation)
    {
        var angle = (rotation.eulerAngles.z + 360) % 360;
        return angle;
    }

    public static float GetAngleFromToTarget(Vector3 source, Vector3 target)
    {
        var vectorToTarget = (target - source).normalized;
        Quaternion rotationToTarget = Quaternion.FromToRotation(Vector3.up, vectorToTarget);
        var angleToTarget = (rotationToTarget.eulerAngles.z + 360) % 360;
        return angleToTarget;
    }
}
