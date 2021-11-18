namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish1;
        private Fish fish2;
        [SetUp]
        public void Setup()
        {
            this.aquarium = new Aquarium("name1", 2);
            this.fish1 = new Fish("fishi");
            this.fish2 = new Fish("fishi2");
        }

        [Test]
        public void TestIfConstructorWorksCorrectly() 
        {
            Assert.IsNotNull(this.aquarium);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void TestNameThrowsAnExceptionIfNullOrEmpty(string name)
        {
            //Aquarium tes1 = new Aquarium(name, 10);
            Assert.Throws<ArgumentNullException>(() => aquarium = new Aquarium(name, 10));
        }

        [Test]
        [TestCase(-14)]
        [TestCase(-45)]
        public void TestCapacityThrowsAnExceptionIfLessThan0(int capacity)
        {
            //Aquarium tes1 = new Aquarium(name, 10);
            Assert.Throws<ArgumentException>(() => aquarium = new Aquarium("name", capacity));
        }

        [Test]
        //[TestCase(-14)]
        //TestCase(-45)]
        public void TestCount()
        {
            //Aquarium tes1 = new Aquarium(name, 10);
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            Assert.That(aquarium.Count == 2);
        }

        [Test]
        public void TestAddMethodThrowsAnException()
        {
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("fishito")));
        }

        [Test]
        public void TestAddMethodAddsTheFish()
        {
            aquarium.Add(fish1);
            //aquarium.Add(fish2);
            Assert.That(aquarium.Count == 1);
            
        }

        [Test]
        public void TestRemoveFishThrowsInvalidOperExceptionIfShishDoesNotExist()
        {
            aquarium.Add(fish1);
            //aquarium.Add(fish2);
            Assert.Throws<InvalidOperationException>(()=> aquarium.RemoveFish("dsds"));

        }

        [Test]
        public void TestRemoveFishRemovedTheFish()
        {
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            aquarium.RemoveFish("fishi");
            Assert.That(aquarium.Count == 1);

        }

        [Test]
        public void TestSellFishSellsTheFish()
        {
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            Fish selledFish = aquarium.SellFish("fishi");
            Assert.That(selledFish.Available == false);
            Assert.That(fish1.Available == false);
            Assert.That(fish1.Name == selledFish.Name);
            //Assert.That();

        }

        [Test]
        public void TestSellFishThrowsInvalidOperExceptionIfShishDoesNotExist()
        {
            aquarium.Add(fish1);
            //aquarium.Add(fish2);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("dsds"));

        }

        [Test]
        public void TestReport()
        {
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            //string fishNames = string.Join(", ", fish.Select(f => f.Name));
            string expectedResult = $"Fish available at {aquarium.Name}: fishi, fishi2";
            string actualResult = aquarium.Report();
            Assert.AreEqual(expectedResult, actualResult);


        }




    }
}
