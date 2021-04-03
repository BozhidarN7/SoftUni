namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Text;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Vehicles;
    using TheTankGame.Entities.Vehicles.Contracts;

    [TestFixture]
    public class BaseVehicleTests
    {
        private IVehicle vehicle;
        [SetUp]
        public void SetUp()
        {
            vehicle = new Revenger("SA-203", 100, 300, 1000, 450, 2000, new VehicleAssembler());
        }
        [Test]
        public void When_ModelProperyCall_ShouldReturnModel()
        {
            Assert.That(vehicle.Model, Is.EqualTo("SA-203"));
        }
        [Test]
        public void When_ModelPropertyValueIsNullOrWhiteSpace_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Revenger("  ", 100, 300, 1000, 450, 2000, new VehicleAssembler()));
            Assert.Throws<ArgumentException>(() => new Revenger(null, 100, 300, 1000, 450, 2000, new VehicleAssembler()));
        }
        [Test]
        public void When_WeighProperyCall_ShouldReturnWight()
        {
            Assert.That(vehicle.Weight, Is.EqualTo(100));
        }
        [Test]
        public void When_WeightPropertyValueLessOrEqualToZero_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Revenger("SA-201", 0, 300, 1000, 450, 2000, new VehicleAssembler()));
        }
        [Test]
        public void When_PriceProperyCall_ShouldReturnPrice()
        {
            Assert.That(vehicle.Price, Is.EqualTo(300));
        }
        [Test]
        public void When_PricePropertyValueLessOrEqualToZero_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Revenger("SA-201", 300, 0, 1000, 450, 2000, new VehicleAssembler()));
        }
        [Test]
        public void When_AttackProperyCall_ShouldReturnAttack()
        {
            Assert.That(vehicle.Attack, Is.EqualTo(1000));
        }
        [Test]
        public void When_AttackPropertyValueLessOrEqualToZero_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Revenger("SA-201", 100, 300, -1, 450, 2000, new VehicleAssembler()));
        }
        [Test]
        public void When_DefenseProperyCall_ShouldReturnDefense()
        {
            Assert.That(vehicle.Defense, Is.EqualTo(450));
        }
        [Test]
        public void When_DefensePropertyValueLessOrEqualToZero_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Revenger("SA-201", 100, 300, 1000, -1, 2000, new VehicleAssembler()));
        }
        [Test]
        public void When_HitPointsProperyCall_ShouldReturnHitPoints()
        {
            Assert.That(vehicle.HitPoints, Is.EqualTo(2000));
        }
        [Test]
        public void When_HitPointsPropertyValueLessOrEqualToZero_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Revenger("SA-201", 100, 300, 1000, 450, -1, new VehicleAssembler()));
        }
        [Test]
        public void When_TotalWeightCall_Should_ReturnTotalWeigh()
        {
            IPart part = new ShellPart("Cannon-KA2", 300, 500, 450);
            vehicle.AddShellPart(part);
            Assert.That(vehicle.TotalWeight, Is.EqualTo(400));
        }
        [Test]
        public void When_TotalPriceCall_Should_ReturnTotalPrice()
        {
            IPart part = new ShellPart("Cannon-KA2", 300, 500, 450);
            vehicle.AddShellPart(part);
            Assert.That(vehicle.TotalPrice, Is.EqualTo(800));
        }
        [Test]
        public void When_TotalDefenseCall_Should_ReturnTotalDefense()
        {
            IPart part = new ShellPart("Cannon-KA2", 300, 500, 450);
            vehicle.AddShellPart(part);
            Assert.That(vehicle.TotalDefense, Is.EqualTo(900));
        }
        [Test]
        public void When_TotalAttackCall_Should_ReturnTotalAttack()
        {
            IPart part = new ArsenalPart("Cannon-KA2", 300, 500, 450);
            vehicle.AddArsenalPart(part);
            Assert.That(vehicle.TotalAttack, Is.EqualTo(1450));
        }
        [Test]
        public void When_TotalHitPointsCall_ShouldReturnTotalHitPoints()
        {
            IPart part = new EndurancePart("Cannon-KA2", 300, 500, 450);
            vehicle.AddEndurancePart(part);
            Assert.That(vehicle.TotalHitPoints, Is.EqualTo(2450));
        }
        [Test]
        public void When_PartsCall_ShouldReturnPointsCollection()
        {
            IPart part = new EndurancePart("Cannon-KA2", 300, 500, 450);
            vehicle.AddEndurancePart(part);
            Assert.That(vehicle.Parts.Count, Is.EqualTo(1));
        }
        [Test]
        public void Test_ToStringMethod()
        {
            string result = "Revenger - SA-203\r\n" +
                    "Total Weight: 100.000\r\n" +
                    "Total Price: 300.000\r\n" +
                    "Attack: 1000\r\n" +
                    "Defense: 450\r\n" +
                    "HitPoints: 2000\r\n" +
                    "Parts: None";

            Assert.That(vehicle.ToString(), Is.EqualTo(result));
        }
    }
}