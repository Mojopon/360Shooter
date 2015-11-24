using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour, IProjectile
{
    public int damage = 1;
    public float speed = 10f;

    protected Rigidbody2D myRigidbody;
    protected MoveForward moveScript;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
        if (moveScript != null)
        {
            moveScript.SetMoveSpeed(speed);
        }
    }

    protected void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        moveScript = new MoveForward(myRigidbody, speed);
    }

    protected void FixedUpdate()
    {
        moveScript.Move(Time.fixedDeltaTime);
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (IsDamageable(other))
        {
            DealDamage(other, other.GetComponent<IDamageable>());
        }

        Destroy(gameObject);
    }

    bool IsDamageable(Collider2D other)
    {
        IDamageable damageableObject = other.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            return true;
        }else
        {
            return false;
        }
    }

    protected virtual void DealDamage(Collider2D collider, IDamageable damageable)
    {
        damageable.TakeHit(damage);
    }
}
