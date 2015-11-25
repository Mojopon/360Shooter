using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : DamageableEntity, IEnemy, IServiceUser {

    public Transform target;
    public float moveSpeed = 3f;
    public float turnSpeed = 50f;

    private Rigidbody2D myRigidBody;
    private MoveForward moveScript;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        moveScript = new MoveForward(myRigidBody, moveSpeed);

        var enemyLocator = serviceLocator.GetEnemyLocator();
        enemyLocator.AddEnemy(this);

        OnDeath += RemoveFromEnemyLocator;
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            if (target == null) return;
        }

        var myAngle = RotationHelper.GetAngleFromQuaternion(transform.rotation);
        var angleToTarget = RotationHelper.GetAngleFromToTarget(transform.position, target.position);
        var diff = RotationHelper.GetDifferenceBetweenAngles(myAngle, angleToTarget);
        float nextAngle = transform.rotation.eulerAngles.z;

        if(diff > 0)
        {
            var mod = turnSpeed * Time.fixedDeltaTime;
            if (mod > diff) mod = diff;
            nextAngle += mod;
        }else if(diff < 0)
        {
            var mod = turnSpeed * Time.fixedDeltaTime;
            if (mod < diff) mod = diff;
            nextAngle -= mod;
        }

        myRigidBody.MoveRotation(nextAngle);

        moveScript.Move(Time.fixedDeltaTime);
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    void RemoveFromEnemyLocator()
    {
        var enemyLocator = serviceLocator.GetEnemyLocator();
        enemyLocator.RemoveEntity(this);
    }

    #region IServiceUser
    private IServiceLocator serviceLocator;
    public void RegisterServiceLocator(IServiceLocator _serviceLocator)
    {
        serviceLocator = _serviceLocator;
    }
    #endregion
}
