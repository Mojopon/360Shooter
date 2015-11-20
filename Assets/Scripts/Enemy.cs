using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour {

    public Transform target;
    public float moveSpeed = 3f;
    public float turnSpeed = 50f;

    private Rigidbody2D myRigidBody;
    private MoveForward moveScript;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        moveScript = new MoveForward(myRigidBody, moveSpeed);
    }

    void FixedUpdate()
    {
        if (target == null) return;

        var angleToTarget = RotationHelper.GetAngleFromToTarget(transform.position, target.position);

        var currentAngle = RotationHelper.GetAngleFromQuaternion(transform.rotation);

        /*
        float nextRotation = currentAngle;
        if(currentAngle > angleToTarget)
        {
            nextRotation = currentAngle - (turnSpeed * Time.fixedDeltaTime);
            if(nextRotation < angleToTarget)
            {
                nextRotation = currentAngle;
            }
        }
        else if(angleToTarget > currentAngle)
        {
            nextRotation = currentAngle + (turnSpeed * Time.fixedDeltaTime);
            if(nextRotation > angleToTarget)
            {
                nextRotation = angleToTarget;
            }
        }
        */

        myRigidBody.MoveRotation(angleToTarget);

        moveScript.Move(Time.fixedDeltaTime);
    }
}
