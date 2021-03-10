using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    [TestCase(100, 100, 100,100,99)]
    [TestCase(45, 45, 50,50,49)]
    public void AxeDecreasesDurability(
        int health,
        int exp,
        int attack,
        int durability,
        int exptectedResult)
    {
        //Arrange
        Dummy dummy = new Dummy(health, exp);
        Axe axe = new Axe(attack, durability);
       
        //Act
        axe.Attack(dummy);

        //Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(exptectedResult), "Durability does not lower");
    }

    [Test]
    public void AttackWithBrokenWeapon()
    {
        //Arranege
        Dummy dummy = new Dummy(10, 10);
        Axe axe = new Axe(20, 0);
        //Act
        Assert.Throws<InvalidOperationException>(
            () => axe.Attack(dummy)
            ) ;

      
    }

}