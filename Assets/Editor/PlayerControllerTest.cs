using UnityEngine;
using NUnit.Framework;
using NSubstitute;

[TestFixture]
public class PlayerControllerTest
{
    PlayerController controller;
    [SetUp]
    public void CreateController()
    {
        controller = new PlayerController();
    }

    [Test]
    public void ShouldShootChargeShotWhenFullCharged()
    {
        IChargeShotController chargeShotController = Substitute.For<IChargeShotController>();
        controller.SetChargeShotController(chargeShotController);

        controller.chargePerSec = 0.5f;
        bool isCharging = true;
        controller.Charge(isCharging, 1);
        chargeShotController.Received().SetCurrentChargeRate(0.5f);
        controller.ChargeShot();
        chargeShotController.DidNotReceive().ChargeShot();

        controller.Charge(isCharging, 1);
        chargeShotController.Received().SetCurrentChargeRate(1f);
        controller.ChargeShot();
        chargeShotController.Received().ChargeShot();
    }
}
