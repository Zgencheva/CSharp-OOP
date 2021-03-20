using FizzBuzz.Contracts;
using FizzBuzz.Tests.Fake;
using Moq;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    public class Tests
    {
        private Mock<IWriter> writer;
        private FizzBuzz fizzBuzz;
        private string Result;
        [SetUp]
        public void Setup()
        {
            writer = new Mock<IWriter>();
            writer.Setup(w => w.WriteLine(It.IsAny<string>()))
                .Callback<string>(i => Result += i);
            fizzBuzz = new FizzBuzz(writer.Object);
            this.Result = "";
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAre1to2ThanResultShouldBeCorrect()
        {
            //Mock<IWriter> writer = new Mock<IWriter>();

            fizzBuzz.PrintNumbers(1, 2);

            Assert.AreEqual("12", Result);
        }
        [Test]
        public void GivenFizzBuzzWhenNumbersAre1to3ThanResultShouldBeCorrect()
        {
            //Mock<IWriter> writer = new Mock<IWriter>();

            fizzBuzz.PrintNumbers(1, 3);

            Assert.AreEqual("12fizz", Result);
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAre4to6ThanResultShouldBeCorrect()
        {
            //Mock<IWriter> writer = new Mock<IWriter>();

            fizzBuzz.PrintNumbers(4,6);

            Assert.AreEqual("4buzzfizz", Result);
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAre14to17ThanResultShouldBeCorrect()
        {
            //Mock<IWriter> writer = new Mock<IWriter>();

            fizzBuzz.PrintNumbers(14, 17);

            Assert.AreEqual("14fizzbuzz1617", Result);
        }

        [Test]
        public void GivenFizzBuzzWhenNumbersAreMinus4to6ThanResultShouldBeCorrect()
        {
            //Mock<IWriter> writer = new Mock<IWriter>();

            fizzBuzz.PrintNumbers(-4, 6);

            Assert.AreEqual("12fizz4buzzfizz", Result);
        }
    }
}