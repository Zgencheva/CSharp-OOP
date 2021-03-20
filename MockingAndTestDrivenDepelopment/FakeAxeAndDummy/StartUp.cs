using FakeAxeAndDummy.Contracts;
using Moq;

public class StartUp
{
    static void Main(string[] args)
    {
        Mock<IWeapon> weapon = new Mock<IWeapon>();
        weapon.Setup(w => w.AttackPoints).Returns(10);


        Mock<ITarget> target = new Mock<ITarget>();
        target.Setup(t => t.GiveExperience()).Returns(20);


        Hero hero = new Hero("Pesho", weapon.Object);
    }
}
