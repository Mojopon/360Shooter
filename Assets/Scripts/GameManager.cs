using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public BoundariesController boundariesController;
    public EnemySpawner enemySpawner;
    public SpawnAlerter spawnAlerter;

    public float battleFieldSizeX = 50f;   
    public float battleFieldSizeY = 50f;

    private Transform playerObject;

    void Awake()
    {
        CreatePlayer();
        CreateBoundariesController();
        CreateEnemySpawner();
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
        newEnemySpawner.SetBattleFieldSize(battleFieldSizeX, battleFieldSizeY);
        newEnemySpawner.spawnAlerter = spawnAlerter;
    }
}
