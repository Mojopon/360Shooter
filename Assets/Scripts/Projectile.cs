using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public int damage = 1;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageableObject = other.GetComponent<IDamageable>();
        if(damageableObject!= null)
        {
            damageableObject.TakeHit(damage);
        }
        Destroy(gameObject);
    }
}
