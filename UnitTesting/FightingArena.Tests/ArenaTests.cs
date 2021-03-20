using NUnit.Framework;
using FightingArena;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        //private List<Warrior> warriors;
        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            //this.warriors = new List<Warrior>();
            
        }
        [Test]

        public void TestConstructorWorksCorrectly()

        {
            Assert.IsNotNull(this.arena.Warriors);
        }
        [Test]
        public void EnrollShouldAddWarriorToTheArena()

        {

            Warrior warrior1 = new Warrior("Warrior", 5, 50);

            this.arena.Enroll(warrior1);

            Assert.That(this.arena.Warriors, Has.Member(warrior1));

        }
        [Test]
        [TestCase(5)]
        [TestCase(6)]
        public void TestCountAndEnrollWorksCorrectly(int countOfWarriors)
        {
            for (int i = 0; i < countOfWarriors; i++)
            {
                Warrior current = new Warrior($"name{i}", 34 + i, 40 + i);
                arena.Enroll(current);
            }

            int expectedResult = countOfWarriors;
            Assert.That(expectedResult == this.arena.Count);
        }

        [Test]
        public void TestEnrollWithDuplicateWarrior()
        {
            
                Warrior current = new Warrior($"Pesho", 34, 40);
            arena.Enroll(current);
            Warrior duplicate = new Warrior($"Pesho", 50, 40);
            Assert.Throws<InvalidOperationException>(
                ()=> arena.Enroll(duplicate)
                );

        }

        [Test]
        [TestCase("Pesho", "Zori")]
        [TestCase("Zori", "Pesho")]
        [TestCase("Zori", "Zori2")]
        public void TestFightWithEmptyWarriors(string attackerName, string defenderName)
        {

            Warrior current = new Warrior($"Pesho", 34, 40);
            arena.Enroll(current);
            Warrior fighter2 = new Warrior($"Gosho", 50, 40);
            arena.Enroll(fighter2);

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight(attackerName, defenderName)
                );

        }


        [Test]
        [TestCase("Gosho", "Pesho")]
        public void TestFightWorksProperly(string attackerName, string defenderName)
        {

            Warrior attacker = new Warrior(attackerName, 10, 50);
            arena.Enroll(attacker);
            Warrior defender = new Warrior(defenderName, 10, 50);
            arena.Enroll(defender);

            arena.Fight(attackerName, defenderName);
            var defenderHP = this.arena.Warriors.FirstOrDefault(x=> x.Name == defenderName).HP;
            var attackerHP = this.arena.Warriors.FirstOrDefault(x=> x.Name == attackerName).HP;
            Assert.AreEqual(attackerHP, 40);
            Assert.AreEqual(defenderHP, 40);

        }

        


    }
}
