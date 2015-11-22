using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameManager : MonoBehaviour, IServiceLocator
{
    public Transform player;
    public BoundariesController boundariesController;
    public EnemySpawner enemySpawner;
    public SpawnAlerter spawnAlerter;
    public EnemyPointer enemyPointer;

    public float battleFieldSizeX = 50f;   
    public float battleFieldSizeY = 50f;

    private Transform playerObject;

    private ServiceLocator serviceLocator;

    void Awake()
    {
        serviceLocator = new ServiceLocator();

        CreatePlayer();
        CreateBoundariesController();
        CreateEnemySpawner();
        CreatePointer();
    }

    void CreatePlayer()
    {
        playerObject = Instantiate(player, Vector3.zero, Quaternion.identity) as Transform;
    }

    void CreateBoundariesController()
    {
        var newBoundariesController = Instantiate(boundariesController, Vector3.zero, Quaternion.identity) as BoundariesController;
        newBoundariesController.SetBattleFieldSize(battleFieldSizeX, battleFieldSizeY);
        newBoundariesController.SetTargetToChase(playerObject);
    }

    void CreateEnemySpawner()
    {
        var newEnemySpawner = Instantiate(enemySpawner, Vector3.zero, Quaternion.identity) as EnemySpawner;
        newEnemySpawner.RegisterServiceLocator(this);
        newEnemySpawner.SetBattleFieldSize(battleFieldSizeX, battleFieldSizeY);
        newEnemySpawner.spawnAlerter = spawnAlerter;
    }

    void CreatePointer()
    {
        var newEnemyPointer = Instantiate(enemyPointer, Vector3.zero, Quaternion.identity) as EnemyPointer;
        newEnemyPointer.RegisterServiceLocator(this);
    }

    #region IServiceLocator MethodGroup

    public EnemyLocator GetEnemyLocator()
    {
        return serviceLocator.GetEnemyLocator();
    }

    #endregion
}
