using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;
        [SetUp]
        public void Setup()
        {
            computerManager = new ComputerManager();
        }

        [Test]
        public void AddComputer_ShouldThrowExceptionWhenComputerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null));
        }
        [Test]
        public void AddComputer_ShouldThrowExceptionWhenComputerExists()
        {
            Computer computer = new Computer("Acer", "predator", 3000);
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer));
        }
        [Test]
        public void AddComputer_ShouldAddToComputerToCollection()
        {
            Computer computer = new Computer("Acer", "predator", 3000);
            computerManager.AddComputer(computer);
            Assert.AreEqual(computerManager.Count, 1);
        }

        [Test]
        public void GetComputerr_ShouldThrowExceptionWhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(null, "predator"));
        }
        [Test]
        public void GetComputer_ShouldThrowExceptionWhenModelIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer("Acer", null));
        }
        [Test]
        public void GetComputer_ShouldThrowExceptionWhenComputerDontExists()
        {
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("Acer", "predator"));
        }
        [Test]
        public void GetComputer_ShouldReturnComputer()
        {
            Computer computer = new Computer("Acer", "predator", 3000);
            computerManager.AddComputer(computer);
            Assert.That(computerManager.GetComputer("Acer", "predator"), Is.EqualTo(computer));
        }
        [Test]
        public void GetComputersByManufacturer_ShouldThrowExceptionWhenManufaturerlIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(null));
        }
        [Test]
        public void GetComputersByManufacturer_ShouldCollectionOfComputerByManufaturer()
        {
            List<Computer> computers = new List<Computer>();
            for (int i = 0; i < 5; i++)
            {
                Computer computer = new Computer($"Acer", $"Predatr{i}", 3000);
                computers.Add(computer);
                computerManager.AddComputer(computer);
            }
            CollectionAssert.AreEqual(computerManager.GetComputersByManufacturer("Acer"), computers);
        }
        [Test]
        public void ComputersProperty_ShouldReturnAllComputers()
        {
            List<Computer> computers = new List<Computer>();
            for (int i = 0; i < 5; i++)
            {
                Computer computer = new Computer($"Acer{i}", $"Predatr{i}", 3000);
                computers.Add(computer);
                computerManager.AddComputer(computer);
            }
            CollectionAssert.AreEqual(computerManager.Computers, computers);
        }
        [Test]
        public void RemoveComputer_ShouldRemoveComputer()
        {
            Computer computer = new Computer("Acer", "predator", 3000);
            computerManager.AddComputer(computer);
            Assert.That(computerManager.RemoveComputer("Acer", "predator"), Is.EqualTo(computer));
            Assert.That(computerManager.Count, Is.EqualTo(0));
        }
        [Test]
        public void RemoveComputer_ShouldThrowExceptionWhenComputerManufacturerIsNull()
        {
            Computer computer = new Computer("Acer", "predator", 3000);
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(null,"predator"));
        }
        [Test]
        public void RemoveComputer_ShouldThrowExceptionWhenComputerModelIsNull()
        {
            Computer computer = new Computer("Acer", "predator", 3000);
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer("Acer", null));
        }
        [Test]
        public void RemoveComputer_ShouldThrowExceptionWhenComputerDontExist()
        {
            Computer computer = new Computer("Acer", "predator", 3000);
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerManager.RemoveComputer("Acer", "Predator"));
        }
        [Test]
        public void ComputersProperty_ShouldCheckWheterContainComputer()
        {
            Computer computer = new Computer("Acer", "predator", 3000);
            computerManager.AddComputer(computer);
            Assert.AreEqual(computerManager.Computers.Any(x => x.Model == "predator"
            && x.Manufacturer == "Acer"), true);
            Assert.AreEqual(computerManager.Count, 1);
            Assert.AreEqual(computerManager.Computers.Count, 1);
        }
    }
}