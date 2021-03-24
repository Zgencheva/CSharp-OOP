using NUnit.Framework;


namespace Chainblock.Tests
{ 

    using ChainBlock;
    using System;
    using ChainBlock.Contracts;
    using ChainBlock.Models;
    using Moq;


    [TestFixture]
    public class ChainblockTests
    {
        public ITransaction Transaction { get; set; }
        public IChainblock ChainBlock { get; set; }
        [SetUp]
        public void Setup()
        {
           this.Transaction = new Transaction()
            {
                Id = 1,
                From = "Filip",
                To = "Victor",
                status = TransactionStatus.Successfull,
                Amount = 1
            };
           this.ChainBlock = new Chainblock();
        }

        [Test]
        [Category("[Add Method]")]
        public void Given_Transaction_When_AddTransactionIsCalled_Then_TransactionCountIncrease()
        {
            //Arrange


            //Act
            ChainBlock.Add(Transaction);

            //Assert
            Assert.AreEqual(1, ChainBlock.Count);
        }

        [Test]
        [Category("[Add Method]")]
        public void Given_DuplicateTransaction_When_AddTransactionIsCalled_Then_InvalidOperationExceptionIsThrown()
        {
            //Arrange
            
            IChainblock chainBlock = new Chainblock();

            //Act
            ChainBlock.Add(Transaction);

            //Assert
            Assert.Throws<InvalidOperationException>
                (
                () => ChainBlock.Add(Transaction)
            
            );
        }

        [Test]
        [Category("[Count property]")]
        public void Given_Count_WhenCountGetterISCalled_Then_ProperNumberIs()
        {
            int expectedChainBlockCount = 0;
            Assert.AreEqual(expectedChainBlockCount, ChainBlock.Count);
  
              
        }

        [Test]
        [Category("[Contains --> Id method]")]
        public void Given_ExcistingId_When_ContainsByIdIsCalled_Then_ReturnsTrue()
        {
            this.ChainBlock.Add(this.Transaction);
            bool result = this.ChainBlock.Contains(this.Transaction.Id);

            Assert.IsTrue(result);
        }

        [Test]
        [Category("[Contains --> Id method]")]
        public void Given_NonExcistingId_When_ContainsByIdIsCalled_Then_ReturnsFalse()
        {
            Assert.That(this.ChainBlock.Contains(this.Transaction.Id), Is.False);

        }

        [Test]
        [Category("[Contains --> Id method]")]
        public void Given_NegativeId_When_ContainsByIdIsCalled_Then_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(
                ()=> this.ChainBlock.Contains(-1)
                );
        }

        [Test]
        [Category("[Contains --> Tx method]")]
        public void Given_ExcistingTx_When_ContainsByTxIsCalled_Then_ReturnsTrue()
        {
            this.ChainBlock.Add(this.Transaction);
            Assert.That(this.ChainBlock.Contains(this.Transaction), Is.True);
        }

        [Test]
        [Category("[Contains --> Tx method]")]
        public void Given_NonExcistingTx_When_ContainsByTxIsCalled_Then_ReturnsFalse()
        {
            Assert.That(this.ChainBlock.Contains(this.Transaction), Is.False);
        }


    }
}