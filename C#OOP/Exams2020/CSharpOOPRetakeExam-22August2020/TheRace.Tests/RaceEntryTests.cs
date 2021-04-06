using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void AddDriver_ShouldThrowExceptionWhenDRriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }
        [Test]
        public void AddDriver_ShouldThrowExceptionWhenDriverDuplicate()
        {
            raceEntry.AddDriver(new UnitDriver("Driver",new UnitCar("Model",5,5)));
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(new UnitDriver("Driver",new UnitCar("Model",5,5))));
        }
        [Test]
        public void AddDriver_ShouldUpdateCounter()
        {
            raceEntry.AddDriver(new UnitDriver("Driver",new UnitCar("Model",5,5)));
            Assert.AreEqual(raceEntry.Counter, 1);
        }
        [Test]
        public void CalculateAverageHorsePower_ShouldThrowExceptionIfCarDriversAreLessThanTheMinimum()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }
        [Test]
        public void CalculateAverageHorsePower_ShouldReturnAverageHorsePower()
        {
            List<UnitDriver> drivers = new List<UnitDriver>();
            for (int i = 0; i < 5; i++)
            {
                UnitDriver driver = new UnitDriver($"Name{i}", new UnitCar($"Model{i}", i, i));
                drivers.Add(driver);
                raceEntry.AddDriver(driver);
            }
            Assert.That(raceEntry.CalculateAverageHorsePower, Is.EqualTo(drivers.Average(x => x.Car.HorsePower)));
        }
    }
}