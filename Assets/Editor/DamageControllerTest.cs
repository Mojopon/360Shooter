using UnityEngine;
using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class DamageControllerTest
{
    Damageable damageable;
    IDamageController controller;

    [SetUp]
    public void CreateDamageController()
    {
        int initialHealth = 10;
        damageable = new Damageable(initialHealth);
        controller = Substitute.For<IDamageController>();
        damageable.SetDamageController(controller);
    }

    [Test]
    public void ShouldDieWhenHealthIsZeroOrMinus()
    {
        damageable.TakeHit(5);
        Assert.False(damageable.IsDead());
        damageable.TakeHit(5);
        Assert.True(damageable.IsDead());
        controller.Received().Die();
    }

    [Test]
    public void ShouldCallOnDeathEventWhenDied()
    {
        bool onDeathEventCalled = false;
        damageable.OnDeath += new System.Action(() => onDeathEventCalled = true);

        damageable.TakeHit(5);
        Assert.False(onDeathEventCalled);
        damageable.TakeHit(5);
        Assert.IsTrue(onDeathEventCalled);
    }
}
