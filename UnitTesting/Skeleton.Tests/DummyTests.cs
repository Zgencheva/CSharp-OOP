using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    [TestCase(30,10,/*20,20,*/10)]
    public void DummyLosesHealthAfterAttack(int health, int experience, /*int attack, int durability*/ int exptectedResult)
    {
        Dummy dummy = new Dummy(health, experience);
        //Axe axe = new Axe(attack, durability);

        dummy.TakeAttack(20);

        Assert.That(dummy.Health == exptectedResult);
    }

    [Test]
    
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        Dummy dummy = new Dummy(0, 100);

        Assert.Throws<InvalidOperationException>(
            ()=> dummy.TakeAttack(120)
            );
    }
    [Test]
    public void DeadDummyCanGiveXP()
    {
        Dummy dummy = new Dummy(0, 100);

        int exptectedResult = 100;
        int result = dummy.GiveExperience();

        Assert.That(exptectedResult == result);
    }

    [Test]
    public void AliveDummyCannotGiveExp()
    {
        Dummy dummy = new Dummy(10, 100);

        Assert.Throws<InvalidOperationException>(
           () => dummy.GiveExperience(), "Target is not dead."
           );
    }

}
