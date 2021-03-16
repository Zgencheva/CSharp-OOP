using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            car = new Car("make", "model", 1.34, 1.67);
            Assert.IsNotNull(this.car);
        }

        [Test]
        [TestCase("make", "model", 1.34, 1.67)]
        [TestCase("dfsdfsd", "fsdfsd", 5.67, 7.45)]
        public void ConstructorShouldCreateCarWith0FeulInside(
            string make, 
            string model, 
            double fuelConsumption,
            double fuelCapacity)
        {
            Car current = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(current.FuelAmount == 0);

        }

        [Test]
        [TestCase("make", "model", 1.34, 1.67)]
        [TestCase("dfsdfsd", "fsdfsd", 5.67, 7.45)]
        public void ConstructorShouldCreateCarWithGivenProperties(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity)
        {
            Car current = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(current.Model == model);
            Assert.That(current.Make == make);
            Assert.That(current.FuelCapacity == fuelCapacity);
            Assert.That(current.FuelConsumption == fuelConsumption);

        }

        [Test]
        [TestCase(null, "model", 1.34, 1.67)]
        [TestCase("", "fsdfsd", 5.67, 7.45)]
        public void ConstructorShouldThrowExceptionIfMakeIsNullOrEmpty(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity)
        {
            //Car current = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(
                ()=> car = new Car(make, model, fuelConsumption, fuelCapacity),
                "Make cannot be null or empty!"
                );

        }

        [Test]
        [TestCase("make", null, 1.34, 1.67)]
        [TestCase("dsfsdfsd", "", 5.67, 7.45)]
        public void ConstructorShouldThrowExceptionIfModelIsNullOrEmpty(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity)
        {
            //Car current = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(
                () => car = new Car(make, model, fuelConsumption, fuelCapacity),
                "Model cannot be null or empty!"
                );

        }

        [Test]
        [TestCase("make", "model", 0, 5.67)]
        [TestCase("dsfsdfsd", "sdasdsa", -5, 7.45)]
        public void FuelConsumptionCannotBeZeroOrNegativeNumber(
            string make,
            string model,
            double fuelConsumption,
            double fuelCapacity)
        {
            //Car current = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(
                () => car = new Car(make, model, fuelConsumption, fuelCapacity),
                "Fuel consumption cannot be zero or negative!"
                );

        }

        [Test]
        [TestCase("make", "model", 5.67, 0)]
        [TestCase("dsfsdfsd", "sdasdsa", 5.78, -5)]
        public void FuelCapacityCannotBeZeroOrNegativeNumber(
           string make,
           string model,
           double fuelConsumption,
           double fuelCapacity)
        {
            //Car current = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(
                () => car = new Car(make, model, fuelConsumption, fuelCapacity),
                "Fuel capacity cannot be zero or negative!"
                );

        }

        [Test]
        [TestCase(0)]
        [TestCase(-4)]
        [TestCase(-453)]
        public void RefuelMethodShouldThrowExceptionIfRefuelAmountIsZeroOrNegative(double refuelAmount)
        {
            car = new Car("make", "model", 1.34, 1.67);

            Assert.Throws<ArgumentException>(
                () => car.Refuel(refuelAmount),
                "Fuel amount cannot be zero or negative!"
                );
        }

        [Test]
        [TestCase(50)]
        [TestCase(100)]
        [TestCase(150)]
        [TestCase(20)]
        [TestCase(44)]
        public void RefuelMethodShouldIncreaseFuelAmountUntillCapacityIsReached(double refuelAmount)
        {
            car = new Car("make", "model", 1.34, 50);
            
            double expectedResult = 0;
            if (this.car.FuelAmount + refuelAmount > this.car.FuelCapacity)
            {
                expectedResult = car.FuelCapacity;
            }
            else
            {
                expectedResult = this.car.FuelAmount + refuelAmount;
            }
            car.Refuel(refuelAmount);
            Assert.That(expectedResult == car.FuelAmount);
        }

        [Test]
        public void TestRefuelingCorrectly()
        {
            car = new Car("make", "model", 5.67, 54);
            this.car.Refuel(15);
            int expectedFuel = 15;

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [Test]
        public void TestRefuelingCorrectlyIfAmountIsMoreThanCapacity()
        {
            car = new Car("make", "model", 5.67, 54);
            this.car.Refuel(60);
            int expectedFuel = 54;

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [Test]
        [TestCase(50)]
        [TestCase(100)]
        [TestCase(150)]
        [TestCase(20)]
        [TestCase(44)]
        public void DriveMethodShouldThrwoExceptionIfFuelIsNotEnough(double distance)
        {
            car = new Car("make", "model", 1.34, 50);
            //double fuelNeeded = (distance / 100) * this.car.FuelConsumption;
            Assert.Throws<InvalidOperationException>(
                () => car.Drive(distance)
                );
           
        }

        [Test]
        public void TestDrivingCorrectly()
        {
            car = new Car("Audi", "A4", 15, 300);
            this.car.Refuel(10);
            this.car.Drive(10);
            double expectedFuel = 8.5;

            Assert.AreEqual(expectedFuel, this.car.FuelAmount);
        }

        [Test]
        [TestCase(50)]
        [TestCase(100)]
        [TestCase(150)]
        [TestCase(20)]
        [TestCase(44)]
        public void DriveMethodShouldDecreeseTheFuelAmount(double distance)
        {
            car = new Car("make", "model", 1.34, 50);
            double fuelNeeded = (distance / 100) * this.car.FuelConsumption;
            car.Refuel(50);
            double expectedResult = car.FuelAmount - fuelNeeded;
            car.Drive(distance);
            double actualResult = car.FuelAmount;
        }

        //[Test]
        //[TestCase("make", "model", 6.8, 1.67)]
        //[TestCase("dsfsdfsd", "sdasdsa", 5.5, 7.45)]
        //public void FuelAmountCannotBeNegativeNum(
        //    string make,
        //    string model,
        //    double fuelConsumption,
        //    double fuelCapacity)
        //{

        //    car = new Car(make, model, fuelConsumption, fuelCapacity);
        //    Assert.Throws<ArgumentException>(
        //        () => car.FuelAmount,
        //        "Fuel consumption cannot be zero or negative!"
        //        );

        //}




    }
}