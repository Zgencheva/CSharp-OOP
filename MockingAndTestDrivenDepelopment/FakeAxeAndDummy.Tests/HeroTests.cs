using FakeAxeAndDummy.Contracts;
using FakeAxeAndDummy.Fakes;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void GivenHeroShouldReceiveExperienceWhenTargetDies()
    {
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

        fakeTarget.Setup(t=> t.GiveExperience()).Returns(20);
        fakeTarget.Setup(t=> t.IsDead()).Returns(true);
        Hero hero = new Hero("Pesho", fakeWeapon.Object);
        hero.Attack(fakeTarget.Object);

        Assert.AreEqual(20, hero.Experience);
    }
}