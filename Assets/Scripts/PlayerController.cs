using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {

    Vector2 velocity;
    float swing;

    Rigidbody2D myRigidBody;

	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();
	}
	
	public void Move(Vector2 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(float _swing)
    {
        swing = -_swing;
    }

    void Update()
    {
        //transform.Rotate(new Vector3(0, 0, 1), -swing * Time.deltaTime);
    }

    void FixedUpdate()
    {
        Quaternion rotation = transform.rotation;
        float z = rotation.eulerAngles.z;
        z += swing * Time.fixedDeltaTime;
        myRigidBody.MoveRotation(z);

        myRigidBody.MovePosition(myRigidBody.position + velocity * Time.fixedDeltaTime);
    }
}
