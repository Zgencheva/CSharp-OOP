using NUnit.Framework;
using System;

namespace Robots.Tests
{


    [TestFixture]
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;
        [SetUp]
        public void SetUp()
        {
            this.robot = new Robot("robot1", 11);
            this.robotManager = new RobotManager(2);
        }

        [Test]
        public void TestIfRobotsConstructorWorksCorrectly()
        {
            Assert.That(robot.MaximumBattery == robot.Battery);
            Assert.IsNotNull(robot);
            Assert.That(robot.MaximumBattery == 11);
            Assert.That(robot.Name == "robot1");
           // Assert.That(robot.Battery == robot.MaximumBattery);
            Assert.That(robot.Battery == 11);
        }

        [Test]
        public void TestIfRobotManagerConstructorWorksCorrectly()
        {
            Assert.That(robotManager.Capacity == 2);
            Assert.IsNotNull(robotManager);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        public void TestIfRobotManagerCapacityThrowsAnExceptionIfLessThanZero(int capacity)
        {
            Assert.Throws<ArgumentException>(
                ()=> this.robotManager = new RobotManager(capacity)/*, "Invalid capacity!"*/
                );
        }

        [Test]
        public void TestIfAddMethodWorks()
        {
            robotManager.Add(robot);
            Assert.That(robotManager.Count == 1);
            
        }

        [Test]
        public void TestIfAddMethodThrowsExceptionIfCapacity()
        {
            robotManager.Add(robot);
            robotManager.Add(new Robot("robot5", 20));
            Assert.Throws<InvalidOperationException>(
                () => robotManager.Add(new Robot("r3", 22))/*, "Not enough capacity!"*/
                );

        }

        [Test]
        public void TestIfAddMethodThrowsExceptionIfSameRobot()
        {
            robotManager.Add(robot);
            
            Assert.Throws<InvalidOperationException>(
                () => robotManager.Add(robot)/*, $"There is already a robot with name {robot.Name}!"*/
                );
        }
        [Test]
        public void TestIFCountMethodWorks() 
        {
            robotManager.Add(robot);
            robotManager.Add(new Robot("rr", 11));
            Assert.That(robotManager.Count == 2);
        }
        [Test]
        public void TestIfRemoveMethodThrowsExceptionIfNotFound()
        {
            //robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Remove(robot.Name)
                //,$"Robot with the name {robot.Name} doesn't exist!"
                );
        }

        [Test]
        public void TestIfRemoveMethodRemovesTheRobot()
        {
            robotManager.Add(robot);
            robotManager.Remove(robot.Name);
            Assert.That(robotManager.Count == 0);
        }

        [Test]
        public void TestIfRemoveMethodRemovesTheRobotWithSameName()
        {
            robotManager.Add(robot);
            robotManager.Add(new Robot("someRo", 12));
            robotManager.Remove(robot.Name);
            Exception ex = Assert.Throws<InvalidOperationException>(
                ()=> robotManager.Remove(robot.Name)
                //,$"Robot with the name {robot.Name} doesn't exist!"
                );
            Assert.AreEqual(ex.Message, $"Robot with the name {robot.Name} doesn't exist!");
        }
        [Test]
        public void TestIfWorkMethodThrowsExceptionIfNotFound()
        {
            robotManager.Add(robot);

            Exception ex = Assert.Throws<InvalidOperationException>(
                () => robotManager.Work("samoName", "someJob", 1)
                //,$"Robot with the name {robot.Name} doesn't exist!"
                );
            Assert.AreEqual(ex.Message, $"Robot with the name samoName doesn't exist!");
        }

        [Test]
        public void TestIfWorkMethodThrowsExceptionIfBatteryNotEnough()
        {
            robotManager.Add(robot);
            Exception ex = Assert.Throws<InvalidOperationException>(
                 () => robotManager.Work("robot1", "someJob", 22));
            Assert.AreEqual(ex.Message, "robot1 doesn't have enough battery!");
               
                
            //Assert.Throws<InvalidOperationException>(
            //    () => robotManager.Work("robot1", "someJob", 22)
            //    ,$"robot1 doesn't have enough battery!"
            //    );
        }


        [Test]
        public void TestIfWorkMethodWorks()
        {
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "someJob", 1);
            Assert.That(robot.Battery == 10);
               
        }

        [Test]
        public void TestIChargekMethodThrowsExceptionIfNotFound()
        {
            //robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(
                () => robotManager.Charge(robot.Name)
                //,$"Robot with the name {robot.Name} doesn't exist!"
                );
        }

        [Test]
        public void TestIChargekMethodWorks()
        {
            robotManager.Add(robot);
            robotManager.Charge(robot.Name);
            Assert.That(robot.MaximumBattery == robot.Battery);
                
        }
    }
}
