namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium("Test", 1);
        }

        [Test]
        public void Constructor_ShouldSetName()
        {
            Assert.AreEqual(aquarium.Name, "Test");
        }
        [Test]
        public void NameProperty_ShouldThrowExceptionIfNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 1));
        }
        [Test]
        public void Constructor_ShouldSetCapacitu()
        {
            Assert.AreEqual(aquarium.Capacity, 1);
        }
        [Test]
        public void CapacityProperty_ShouldThrowExceptionIfNegative()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Test", -2));
        }

        [Test]
        public void AddFish_ShouldThrowExceptionIfCapacityExceeded()
        {
            Fish fish = new Fish("Pesho");
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish));
        }
        [Test]
        public void AddFish_ShouldIncreaseCount()
        {
            Fish fish = new Fish("Pesho");
            aquarium.Add(fish);
            Assert.AreEqual(aquarium.Count, 1);
        }
        [Test]
        public void RemoveFish_ShouldThrowExceptionIfFishNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Pesho"));
        }
        [Test]
        public void RemoveFish_ShouldDecreaseCount()
        {
            Fish fish = new Fish("Pesho");
            aquarium.Add(fish);
            aquarium.RemoveFish("Pesho");
            Assert.AreEqual(aquarium.Count, 0);
        }
        [Test]
        public void SellFish_ShouldThrowExceptionIfFishNotExists()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Pesho"));
        }
        [Test]
        public void SellFish_ShouldMakeFishUnavaible()
        {
            aquarium.Add(new Fish("Pesho"));
            Assert.AreEqual(aquarium.Count, 1);
            Assert.That(aquarium.SellFish("Pesho").Available, Is.EqualTo(false));
        }
        [Test]
        public void Report_ShouldReturnNameOfAvailableFish()
        {
            Aquarium aquarium1 = new Aquarium("Test", 3);
            for (int i = 0; i < aquarium1.Capacity; i++)
            {
                aquarium1.Add(new Fish($"Pesho {i}"));
            }
            Assert.AreEqual(aquarium1.Report(), "Fish available at Test: Pesho 0, Pesho 1, Pesho 2");
        }
        
    }
}
