using UnityEngine;
using System.Collections;

public interface IServiceLocator
{
    EnemyLocator GetEnemyLocator();
}
