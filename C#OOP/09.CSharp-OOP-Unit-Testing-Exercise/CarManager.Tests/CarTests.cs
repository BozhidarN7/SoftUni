using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("", "Model", 4, 29)]
        [TestCase(null, "Model", 4, 29)]
        [TestCase("Make", "", 4, 29)]
        [TestCase("Make", null, 4, 29)]
        [TestCase("Make", "Model", -5, 29)]
        [TestCase("Make", "Model", 4, -29)]
        public void When_CtorIsCallWithInvalidData_ShouldThrowExceptin(
            string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(
                make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void When_CtorInvolve_ShoultCreateCar()
        {
            string make = "make";
            string model = "model";
            double fuelConsumption = 4;
            double fuelCapacity = 29;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.Make == make && car.Model == model &&
                car.FuelConsumption == fuelConsumption &&
                car.FuelCapacity == fuelCapacity &&
                car.FuelAmount == 0);
        }
        [Test]
        public void When_MakePropertyCall_ShouldReturnMakeValue()
        {
            Car car = new Car("make", "model", 4, 29);
            Assert.That(car.Make, Is.EqualTo("make"));
        }
        [Test]
        public void When_ModelPropertyCall_ShouldReturnModelValue()
        {
            Car car = new Car("make", "model", 4, 29);
            Assert.That(car.Model, Is.EqualTo("model"));
        }
        [Test]
        public void When_FuelConsumptionPropertyCall_ShouldReturnFuelConsumptionValue()
        {
            Car car = new Car("make", "model", 4, 29);
            Assert.That(car.FuelConsumption, Is.EqualTo(4));
        }
        [Test]
        public void When_FuelCapacityPropertyCall_ShouldReturnFuelCapacityValue()
        {
            Car car = new Car("make", "model", 4, 29);
            Assert.That(car.FuelCapacity, Is.EqualTo(29));
        }
        [Test]
        public void When_RefuelCallWithNagativeValue_ShouldThrowException()
        {
            Car car = new Car("make", "model", 4, 29);
            Assert.Throws<ArgumentException>(() => car.Refuel(-4));
        }
        [Test]
        public void WhenRefuelWithZero_ShouldThrowException()
        {
            Car car = new Car("make", "model", 4, 29);
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
        }
        [Test]
        public void When_RefuelCall_ShouldIncreaseFuelAmount()
        {
            Car car = new Car("make", "model", 4, 29);
            int newFuel = 4;
            double carFuel = car.FuelAmount;
            car.Refuel(newFuel);
            Assert.AreEqual(car.FuelAmount, carFuel + newFuel);
        }
        [Test]
        public void When_RefuelCall_ShuoldSetFuelToMaxCapacityIfBigger()
        {
            Car car = new Car("make", "model", 4, 5);
            int newFuel = 6;
            car.Refuel(newFuel);
            Assert.AreEqual(car.FuelAmount, car.FuelCapacity);
        }
        [Test]
        public void When_DriveCall_ShuoldThrowExceptoinIfThereIsNotEnoughFuel()
        {
            Car car = new Car("make", "model", 4, 30);
            car.Refuel(3);
            int distance = 100;
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }
        [Test]
        public void When_DriveCall_ShouldDecreaseFuelAmount()
        {
            Car car = new Car("make", "model", 4, 100);
            double fuelAmount = 10;
            car.Refuel(fuelAmount);
            int distance = 100;
            fuelAmount -= (distance / 100) * car.FuelConsumption;
            car.Drive(distance);
            Assert.AreEqual(car.FuelAmount,fuelAmount);
        }
    }
}