using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
        }

        [Test]
        public void When_CtorInvolve_ShouldInitializeCollectionWithTwelveElements()
        {
            Assert.That(new BankVault().VaultCells.Count, Is.EqualTo(12));
        }
        [Test] 
        public void When_AddItemCallWithWrongCell_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("d5", new Item("Test", "1")));
        }
        [Test]
        public void WhenAddItemCallAndCellIsNotEmpty_ShouldThrowException()
        {
            bankVault.AddItem("A1", new Item("Test1", "1"));
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", new Item("Test2", "2")));
        }
        [Test]
        public void WhenAddItemCallAndItemIsPresentedInTheCell_ShouldThrowException()
        {
            bankVault.AddItem("A1", new Item("Test1", "1"));
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", new Item("Test1", "1")));
        }
        [Test]
        public void WhenAddItemCall_ShouldAddItemToGivenCell()
        {
            bankVault.AddItem("A1", new Item("Test1", "1"));
            Assert.AreNotEqual(bankVault.VaultCells["A1"], null);
        }
        [Test]
        public void When_RemoveItemCallWithWrongCell_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("d5", new Item("Test", "1")));
        }
        [Test]
        public void WhenRemoveItemCallAndCellIsNotEmpty_ShouldThrowException()
        {
            bankVault.AddItem("A1", new Item("Test1", "1"));
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", new Item("Test2", "2")));
        }
        [Test]
        public void WhenRemoveItemCall_ShouldRemoveItemAtTheGivenCell()
        {
            Item item = new Item("Test1", "1");
            bankVault.AddItem("A1", item);
            bankVault.RemoveItem("A1", item);
            Assert.AreEqual(bankVault.VaultCells["A1"], null);
        }
    }
}