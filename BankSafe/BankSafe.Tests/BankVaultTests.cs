using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        private BankVault bankValut;
        private Item item;
        [SetUp]
        public void Setup()
        {
        }

        //check the constructor
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            bankValut = new BankVault();
            Assert.IsNotNull(this.bankValut);
        }

        [Test]
        public void TestIfConstructorCreatesListWith12ItemInside()
        {
            bankValut = new BankVault();
            Assert.That(bankValut.VaultCells.Count == 12);
        }
        [Test]
        [TestCase("A3")]
        [TestCase("B3")]
        [TestCase("C1")]
        public void TestIfConstructorCreatesDictionaryWithConcretKeys(string key)
        {
            bankValut = new BankVault();
            Assert.That(bankValut.VaultCells.ContainsKey(key));
        }
        [Test]
        [TestCase("A3")]
        [TestCase("B3")]
        [TestCase("C1")]
        public void TestIfConstructorCreatesDictionaryWithConcretKeysAndNullItems(string key)
        {
            bankValut = new BankVault();
            Assert.IsNull(bankValut.VaultCells[key]);
        }

        //check the ADD method:
        [Test]
        [TestCase("A5")]
        [TestCase("C5")]
        [TestCase("B7")]
        public void TestIfAddMethodThrowsExceptionIfCellDoesntExiest(string cell)
        {
            bankValut = new BankVault();
            item = new Item("Pesho", "Item3345");
            Assert.Throws<ArgumentException>(() => bankValut.AddItem(cell, item), "Cell doesn't exists!");
        }

        [Test]
        public void TestIfAddMethodThrowsExceptionIfCellIsAlreadyTaken()
        {
            bankValut = new BankVault();
            item = new Item("Pesho", "Item3345");
            Item item2 = new Item("Gosho", "Itemsjfjf");
            bankValut.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankValut.AddItem("A1", item2), "Cell is already taken!");
        }

        [Test]
        public void TestIfAddMethodThrowsExceptionIfItemAlreadyExists()
        {
            bankValut = new BankVault();
            item = new Item("Pesho", "Item3345");
            
            bankValut.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() => bankValut.AddItem("A3", item), "Item is already in cell!");
        }

        [Test]
        public void TestIfAddMethodAddsTheItem()
        {
            bankValut = new BankVault();
            item = new Item("Pesho", "Item3345");
            bankValut.AddItem("A1", item);
            Assert.That(bankValut.VaultCells["A1"].ItemId == item.ItemId);
            //Assert.That(bankValut.VaultCells.Count == 1);
        }

        [Test]
        public void TestIfAddMethodReturnsCorrectMEssageWhenItemIsAdded()
        {
            bankValut = new BankVault();
            item = new Item("Pesho", "Item3345");
            string result = bankValut.AddItem("A1", item);
            Assert.That(result == $"Item:{item.ItemId} saved successfully!");
            //Assert.That(bankValut.VaultCells.Count == 1);
        }
        //check the ADD method:
        [Test]
        [TestCase("A5")]
        [TestCase("C5")]
        [TestCase("B7")]
        public void TestIfRemoveMethodThrowsExceptionIfCellDoesntExiest(string cell)
        {
            bankValut = new BankVault();
            item = new Item("Pesho", "Item3345");
            Assert.Throws<ArgumentException>(() => bankValut.RemoveItem(cell, item), "Cell doesn't exists!");
        }

        [Test]
        public void TestIfRemoveMethodThrowsExceptionIfItemOnTheCellIsNotTheSame()
        {
            bankValut = new BankVault();
            item = new Item("Pesho", "Item3345");
            Item item2 = new Item("Gosho", "Itemsjfjf");
            bankValut.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankValut.RemoveItem("A1", item2), "Item in that cell doesn't exists!");
        }

        [Test]
        public void TestIfRemoveMethodSetsTheValueToNull()
        {
            bankValut = new BankVault();
            item = new Item("Pesho", "Item3345");
           
            bankValut.AddItem("A1", item);
            bankValut.RemoveItem("A1", item);
            Assert.That(bankValut.VaultCells["A1"] == null);
        }

        [Test]
        public void TestIfRemoveMethodReturnsCorrectMEssageWhenItemIsAdded()
        {
            bankValut = new BankVault();
            item = new Item("Pesho", "Item3345");
            bankValut.AddItem("A1", item);
            string result = bankValut.RemoveItem("A1", item);
            Assert.That(result == $"Remove item:{item.ItemId} successfully!");
            //Assert.That(bankValut.VaultCells.Count == 1);
        }
    }
}