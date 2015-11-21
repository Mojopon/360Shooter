using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public Wave[] waves;
    public Enemy enemy;

    private int currentWaveNumber = 0;

    private Transform playerObject;
    private float battleFieldWidth;
    private float battleFieldHeight;

    public void SetBattleFieldSize(float width, float height)
    {
        battleFieldWidth = width;
        battleFieldHeight = height;
    }

    private int remainingEnemies;
    public void Update()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player").transform;

        if(playerObject == null || remainingEnemies > 0 || currentWaveNumber >= waves.Length)
        {
            return;
        }
        
        StartCoroutine(SpawnWave(waves[currentWaveNumber]));
    }

    IEnumerator SpawnWave(Wave wave)
    {
        remainingEnemies = wave.enemyCount;
        var waitTime = wave.timeBetweenSpawns;

        for(int i = 0; i < wave.enemyCount; i++) { 
            var playerPosition = playerObject.position;
            var positionToSpawn = new Vector3(playerPosition.x + Random.Range(-battleFieldWidth / 2f, battleFieldWidth / 2f),
                                              playerPosition.y + Random.Range(-battleFieldHeight / 2f, battleFieldHeight / 2f),
                                              0);
            var newEnemy = Instantiate(enemy, positionToSpawn, Quaternion.identity) as Enemy;
            newEnemy.OnDeath += OnEnemyDeath;  

            yield return new WaitForSeconds(waitTime);
        }

        currentWaveNumber++;
    }

    void OnEnemyDeath()
    {
        remainingEnemies--;
    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}
