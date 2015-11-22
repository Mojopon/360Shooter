using UnityEngine;
using System.Collections;
using System;

public class ServiceLocator : IServiceLocator
{
    private EnemyLocator enemyLocator;

    public ServiceLocator()
    {
        enemyLocator = new EnemyLocator();
    }

    public EnemyLocator GetEnemyLocator()
    {
        return enemyLocator;
    }
}
