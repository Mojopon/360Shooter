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

    [Test]
    public void ShouldAccelerateAndDecelerate()
    {
        IMovementController movementController = Substitute.For<IMovementController>();
        int defaultGear = 1;
        int[] gears = new int[]
        {
            3,
            5,
            7,
        };

        controller.currentGear = defaultGear;
        controller.gears = gears;
        controller.SetMovementController(movementController);

        // Should set default speed
        controller.Initialize();
        movementController.Received().SetSpeed(gears[1]);

        // Should change gear and accelerate
        movementController.ClearReceivedCalls();
        controller.Accelerate();
        movementController.Received().SetSpeed(gears[2]);

        // should not accelerate when its already highest gear
        movementController.ClearReceivedCalls();
        controller.Accelerate();
        movementController.DidNotReceive().SetSpeed(Arg.Any<int>());

        // Should change gear and decelerate
        movementController.ClearReceivedCalls();
        controller.Decelerate();
        movementController.Received().SetSpeed(gears[1]);
        movementController.ClearReceivedCalls();
        controller.Decelerate();
        movementController.Received().SetSpeed(gears[0]);

        // should not decelerate when its already lowest gear
        movementController.ClearReceivedCalls();
        controller.Decelerate();
        movementController.DidNotReceive().SetSpeed(gears[0]);
    }
}
