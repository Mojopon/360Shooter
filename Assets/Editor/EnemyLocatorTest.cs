using UnityEngine;
using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class EnemyLocatorTest
{
	[Test]
    public void ShouldReturnNearestEnemy()
    {
        var enemyLocator = new EnemyLocator();

        var enemyOne = Substitute.For<IEnemy>();
        var enemyTwo = Substitute.For<IEnemy>();
        var enemyThree = Substitute.For<IEnemy>();

        enemyOne.GetPosition().Returns(new Vector3(0, -2));
        enemyTwo.GetPosition().Returns(new Vector3(1, 2));
        enemyThree.GetPosition().Returns(new Vector3(2, 4));

        enemyLocator.AddEnemy(enemyOne);
        enemyLocator.AddEnemy(enemyTwo);
        enemyLocator.AddEnemy(enemyThree);

        var player = Substitute.For<IFieldEntity>();
        player.GetPosition().Returns(new Vector3(0, 0));
        var nearestEnemy = enemyLocator.GetNearestEnemyFromTheEntity(player);

        Assert.AreEqual(enemyOne, nearestEnemy);
    }
}
