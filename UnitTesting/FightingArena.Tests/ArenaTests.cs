using NUnit.Framework;
using FightingArena;
using System.Collections.Generic;
using System;

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
        public void TestFightWithEmptyWarrior(string attackerName, string defenderName)
        {

            Warrior current = new Warrior($"Pesho", 34, 40);
            arena.Enroll(current);
            Warrior fighter2 = new Warrior($"Gosho", 50, 40);
            arena.Enroll(fighter2);

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight(attackerName, defenderName),
                $"There is no fighter with name Zori enrolled for the fights!"
                );

        }

        [Test]
        [TestCase("Zori", "Pesho")]
        public void TestFightWithEmptyWarrior2(string attackerName, string defenderName)
        {

            Warrior current = new Warrior($"Pesho", 34, 40);
            arena.Enroll(current);
            Warrior fighter2 = new Warrior($"Gosho", 50, 40);
            arena.Enroll(fighter2);

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight(attackerName, defenderName),
                $"There is no fighter with name Zori enrolled for the fights!"
                );

        }

        [Test]
        [TestCase("Gosho", "Pesho")]
        public void TestFightWorksProperly(string attackerName, string defenderName)
        {

            Warrior current = new Warrior(attackerName, 34, 40);
            arena.Enroll(current);
            Warrior fighter2 = new Warrior(defenderName, 35, 40);
            arena.Enroll(fighter2);

            arena.Fight(attackerName, defenderName);

            Assert.That(current.HP == 5);

        }


    }
}
