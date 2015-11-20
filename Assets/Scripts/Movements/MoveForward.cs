using UnityEngine;
using System.Collections;

public class MoveForward
{
    private float moveSpeed;
    private Rigidbody2D myRigidBody;
    public MoveForward(Rigidbody2D _myRigidBody, float _moveSpeed)
    {
        myRigidBody = _myRigidBody;
        SetMoveSpeed(_moveSpeed);
    }
	
    public void SetMoveSpeed(float _moveSpeed)
    {
        moveSpeed = _moveSpeed;
    }

    public void Move(float timeStep)
    {
        var velocity = myRigidBody.transform.rotation * Vector3.up * moveSpeed;
        myRigidBody.MovePosition(myRigidBody.position + (Vector2)velocity * timeStep);
    }
}
