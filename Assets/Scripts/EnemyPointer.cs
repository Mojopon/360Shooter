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

            transform.position = playerObject.position;
            transform.SetParent(playerObject);
            player = playerObject.GetComponent<Player>();
        }

        var enemyLocator = serviceLocator.GetEnemyLocator();
        var nearestEnemy = enemyLocator.GetNearestEnemyFromTheEntity(player);

        if (nearestEnemy == null) return;

        var angleToNearestEnemy = RotationHelper.GetAngleFromToTarget(player.GetPosition(), nearestEnemy.GetPosition());

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, angleToNearestEnemy);
    }

    #region IServiceUser
    private IServiceLocator serviceLocator;
    public void RegisterServiceLocator(IServiceLocator _serviceLocator)
    {
        serviceLocator = _serviceLocator;
    }
    #endregion
}
