using NUnit.Framework;
using System;
using UnitTesting;

namespace UnitTesting_Tests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        //[TestCase("Stoyan")]
        //[TestCase("Ivan")]
        public void DoesMyNameWorksProperly()
        {
            //arrange!
            Person person = new Person("Stoyan");

            //act!
            string expectedResult = "My name is Stoyan";
            string actualResult = person.WhatsMyName();

            //assert!
            //Assert.AreEqual(expectedResult, actualResult);
            //Assert.Throws<Exception>(
            //    () => person.WhatsMyName()
            //    ) ;
            Assert.That(expectedResult == actualResult);
        }
    }
}
