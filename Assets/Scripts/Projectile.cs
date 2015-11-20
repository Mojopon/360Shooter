using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    float moveSpeed = 10;

    private Rigidbody2D myRigidbody;
    private MoveForward moveScript;

    public void SetSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
        if (moveScript != null)
        {
            moveScript.SetMoveSpeed(moveSpeed);
        }
    }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        moveScript = new MoveForward(myRigidbody, moveSpeed);
    }

    void FixedUpdate()
    {
        moveScript.Move(Time.fixedDeltaTime);
    }
}
