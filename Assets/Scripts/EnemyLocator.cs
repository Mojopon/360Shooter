using UnityEngine;
using System.Collections.Generic;

public class EnemyLocator 
{
    private List<IEnemy> enemies;
    public EnemyLocator()
    {
        enemies = new List<IEnemy>();
    }
	
    public void AddEnemy(IEnemy entity)
    {
        enemies.Add(entity);
    }

    public void RemoveEntity(IEnemy entity)
    {
        enemies.Remove(entity);
    }
         
    public IEnemy GetNearestEnemyFromTheEntity(IFieldEntity entity)
    {
        IEnemy nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;

        foreach(IEnemy enemy in enemies)
        {
            float distanceToTheEntity = Vector2.Distance(entity.GetPosition(), enemy.GetPosition());
            if (nearestDistance > distanceToTheEntity)
            {
                nearestDistance = distanceToTheEntity;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }
}
