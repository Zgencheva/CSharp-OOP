using NUnit.Framework;
using FightingArena;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior("warName", 25, 233);
        }

        [Test]
        [TestCase("warName", 25, 233)]
        [TestCase("warName", 100, 78)]
        [TestCase("warName", 39, 45)]
        public void ConstructorWorksProperlyWithCorrectData(string name, int damage, int hp)
        {
            warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
            Assert.IsNotNull(this.warrior);
        }

        [Test]
        [TestCase(null, 25, 233)]
        [TestCase(" ", 100, 78)]
        [TestCase("", 100, 78)]
        
        public void NameCannotBeNullOrwhitespace(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(
                ()=> warrior = new Warrior(name, damage, hp)
                ); 
        }

        [Test]
        [TestCase("dasdas", 0, 233)]
        [TestCase("dasdaas", -8, 78)]
      
        public void DamageValueShouldBePositiveNumber(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(
                () => warrior = new Warrior(name, damage, hp)
                );
        }

        [Test]
        [TestCase("dasdas", 5454, -85)]
        [TestCase("dasdaas", 453, -74)]
        public void HPCannotBeNEgativeNum(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(
                () => warrior = new Warrior(name, damage, hp)
                );
        }

        [Test]
        [TestCase("dasdas", 5454, 20)]
        [TestCase("dasdaas", 453, 22)]
        [TestCase("dasdaas", 453, 30)]
        public void WarriorCannotAttackIfHisHPIsLessThan30(string name, int damage, int hp)
        {
            warrior = new Warrior(name, damage, hp);
            Warrior warriorToAttack = new Warrior(name, damage, 100);
            Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(warriorToAttack)
                );
        }

        [Test]
        [TestCase("dasdas", 5454, 100, 20)]
        [TestCase("dasdaas", 453, 50, 30)]
        [TestCase("dasdaas", 453, 120, 1)]
        public void WarriorCannotAttackWarriorWhichHPIsBelow30(string name, int damage, int hp, int attackedWarriorHP)
        {
            warrior = new Warrior(name, damage, hp);
            Warrior warriorToAttack = new Warrior(name, damage, attackedWarriorHP);
            Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(warriorToAttack)
                );
        }

        [Test]
        [TestCase("dasdas", 50, 50, 60)]
        [TestCase("dasdaas", 60, 50, 70)]
        [TestCase("dasdaas", 55, 50, 85)]
        public void WarriorCannotAttackStrongerWarrior(string name, int damage, int hp, int attackedWorriorDamage)
        {
            warrior = new Warrior(name, damage, hp);
            Warrior warriorToAttack = new Warrior(name, attackedWorriorDamage, hp);
            Assert.Throws<InvalidOperationException>(
                () => warrior.Attack(warriorToAttack)
                );
        }

        [Test]
        public void WarriorHPShouldBeDecreesedWithDamageValueOfTheAttackedWarrior()
        {
            //Arrange
            Warrior warriorToAttack = new Warrior("attackedOne", 10, 100);

            //Act
            warrior.Attack(warriorToAttack);

            //Assert
            int expectedResult = 233 - 10;
            Assert.That(expectedResult == warrior.HP); 
        }

        [Test]
        public void AttackedWarriorShouldLooseHPWithDamageValueOfTheWarrior()
        {
            //Arrange
            Warrior warriorToAttack = new Warrior("attackedOne", 10, 100);

            //Act
            warrior.Attack(warriorToAttack);

            //Assert
            int expectedResult = 100 - 25;
            Assert.That(expectedResult == warriorToAttack.HP);
        }

        [Test]
        public void AttackedWarriorShouldLooseAllHPIfDamageOfTheWorriorIsMoreThanHisHP()
        {
            //Arrange
            Warrior warriorToAttack = new Warrior("attackedOne", 100, 100);
            warrior = new Warrior("war", 120, 100);
            //Act
            warrior.Attack(warriorToAttack);

            //Assert
            int expectedResult = 0;
            Assert.That(expectedResult == warriorToAttack.HP);
        }




    }
}