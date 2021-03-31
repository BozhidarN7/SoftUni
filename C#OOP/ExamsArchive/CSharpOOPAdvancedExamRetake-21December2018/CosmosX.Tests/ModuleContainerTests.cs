namespace CosmosX.Tests
{
    using CosmosX.Entities.Containers;
    using CosmosX.Entities.Modules.Absorbing;
    using CosmosX.Entities.Modules.Energy;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ModuleContainerTests
    {
        private  ModuleContainer moduleContainer;
        [SetUp]
        public void SetUp()
        {
            moduleContainer = new ModuleContainer(2);
        }
        [Test]
        public void When_AddEnergyModuleCall_ShouldThrowExceptionIfGivenModuleIsNull()
        {
            Assert.Throws<ArgumentException>(() => moduleContainer.AddEnergyModule(null));
        }
        [Test]
        public void When_AddEnergyModuleCall_ShouldRemoveFirstIfCapacityExceeded()
        {
            CryogenRod second = new CryogenRod(2, 2);
            moduleContainer.AddEnergyModule(new CryogenRod(1,2));
            moduleContainer.AddEnergyModule(second);
            moduleContainer.AddEnergyModule(new CryogenRod(3, 2));

            Assert.AreEqual(second, moduleContainer.ModulesByInput.First());
        }
        [Test]
        public void When_TotalEnergyOutputCall_ShouldCalculteEnergyOutput()
        {
            moduleContainer.AddEnergyModule(new CryogenRod(1, 2));
            Assert.That(moduleContainer.TotalEnergyOutput, Is.EqualTo(2));
        }

        [Test]
        public void WhenAddAbsorbingModuleCall_ShouldThrowExceptionIfGivenModuleIsNull()
        {
            Assert.Throws<ArgumentException>(() => moduleContainer.AddAbsorbingModule(null));
        }
        [Test]
        public void When_TotalHeatAbsorbinCall_ShouldReturnTheHeatAbsorbedFromAllModules()
        {
            moduleContainer.AddAbsorbingModule(new HeatProcessor(1, 2));
            Assert.That(moduleContainer.TotalHeatAbsorbing, Is.EqualTo(2));
        }
        [Test]
        public void When_ConstructorInvolve_ShouldInitializeStructures()
        {
            ModuleContainer mc = new ModuleContainer(1);
            Assert.That(mc.ModulesByInput.Count, Is.EqualTo(0));
            Assert.That(mc.TotalEnergyOutput, Is.EqualTo(0));
            Assert.That(mc.TotalHeatAbsorbing, Is.EqualTo(0));
        }
    }
}