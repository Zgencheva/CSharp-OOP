using System;
using NUnit.Framework;
using Demo;


namespace DemoTests
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void WhatsMyNameWorksProperly()
        {
            Person person = new Person("Stoyan");

            string result = person.WhatsMyName();
            string expectedResult = "Stoyan";

            Assert.AreEqual(result, expectedResult);


        }
    }
}
