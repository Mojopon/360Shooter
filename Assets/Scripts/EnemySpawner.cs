using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemy;

    private float battleFieldWidth;
    private float battleFieldHeight;

    public void SetBattleFieldSize(float width, float height)
    {
        battleFieldWidth = width;
        battleFieldHeight = height;
    }
	
    private float nextSpawn;
    public void Update()
    {
        Transform playerObject = GameObject.FindGameObjectWithTag("Player").transform;

        if(nextSpawn > Time.time || playerObject == null)
        {
            return;
        }

        var playerPosition = playerObject.position;
        var positionToSpawn = new Vector3(playerPosition.x + Random.Range(-battleFieldWidth / 2f, battleFieldWidth /2f),
                                          playerPosition.y + Random.Range(-battleFieldHeight / 2f, battleFieldHeight / 2f),
                                          0);
        Instantiate(enemy, positionToSpawn, Quaternion.identity);

        nextSpawn = Time.time + 2;
    }
}
