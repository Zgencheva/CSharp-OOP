using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private Dummy dummy;
    private Axe axe;

    [SetUp]
    public void Initialize()
    {
        this.dummy = new Dummy(10,10);
        this.axe = new Axe(10,10);
    }
    
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
        dummy = new Dummy(health, exp);
        axe = new Axe(attack, durability);
       
        //Act
        axe.Attack(dummy);

        //Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(exptectedResult), "Durability does not lower");
    }

    [Test]
    public void AttackWithBrokenWeapon()
    {
        //Arranege
        //Dummy dummy = new Dummy(10, 10);
        //Axe axe = new Axe(20, 0);
        //Act
        Assert.Throws<InvalidOperationException>(
            () => axe.Attack(dummy)
            ) ;

      
    }

}