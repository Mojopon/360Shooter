using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    private float moveSpeed;
    private float swing;

    private MoveForward moveScript;
    private Rigidbody2D myRigidBody;

	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
        moveScript = new MoveForward(myRigidBody, moveSpeed);
	}
	
	public void SetSpeed(float _moveSpeed)
    {
        moveSpeed = _moveSpeed;
        if(moveScript!= null) 
            moveScript.SetMoveSpeed(moveSpeed);
    }

    public void SetRotatingMovement(float _swing)
    {
        swing = -_swing;
    }

    void FixedUpdate()
    {
        // turn the ship
        Quaternion rotation = transform.rotation;
        float z = rotation.eulerAngles.z;
        z += swing * Time.fixedDeltaTime;
        myRigidBody.MoveRotation(z);

        // move forward
        moveScript.Move(Time.fixedDeltaTime);
    }
}
