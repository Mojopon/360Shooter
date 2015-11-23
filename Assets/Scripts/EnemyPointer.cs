using UnityEngine;
using System.Collections;

public class EnemyPointer : MonoBehaviour, IServiceUser
{
    private Player player;

    void Update()
    {
        if (player == null)
        {
            Transform playerObject = GameObject.FindGameObjectWithTag("Player").transform;
            if (playerObject == null) return;

            player = playerObject.GetComponent<Player>();
        }

        transform.position = player.GetPosition();
        var enemyLocator = serviceLocator.GetEnemyLocator();
        var nearestEnemy = enemyLocator.GetNearestEnemyFromTheEntity(player);

        if (nearestEnemy == null) return;

        var angleToNearestEnemy = RotationHelper.GetAngleFromToTarget(player.GetPosition(), nearestEnemy.GetPosition());
        var newAngle = Mathf.Lerp(transform.rotation.eulerAngles.z, angleToNearestEnemy, 0.5f);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, newAngle);
    }

    #region IServiceUser
    private IServiceLocator serviceLocator;
    public void RegisterServiceLocator(IServiceLocator _serviceLocator)
    {
        serviceLocator = _serviceLocator;
    }
    #endregion
}
