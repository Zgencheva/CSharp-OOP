using System;
using NUnit.Framework;
[TestFixture]
public class HeroRepositoryTests
{
    private Hero hero;
    private HeroRepository heroRep;
    [SetUp]
    public void Setup()
    {
        this.hero = new Hero("name", 1);
        this.heroRep = new HeroRepository();
    }

    [Test]
    public void TestHeroConstructor()
    {
        Assert.AreEqual(hero.Name, "name");
        Assert.AreEqual(hero.Level, 1);
        Assert.NotNull(hero);
    }

    [Test]
    public void TestHeroRepConstr()
    {
        Assert.AreEqual(heroRep.Heroes.Count,0);
        
    }

    [Test]
    public void TestIfCreateMethodThrowsArgExcIfHEroIsNull()
    {
        Assert.Throws<ArgumentNullException>(()=> heroRep.Create(null));

    }


    [Test]
    public void TestIfCreateMethodThrowsArgExcIfHEroNameExist()
    {
        heroRep.Create(hero);
        Assert.Throws<InvalidOperationException>(() => heroRep.Create(hero));

    }

    [Test]
    public void TestIfCreateMethodAddTheHero()
    {
        heroRep.Create(hero);
        Assert.That(heroRep.Heroes.Count == 1);
        Hero expected = heroRep.GetHero("name");
        Assert.AreEqual(hero.Name, expected.Name);
        string message = heroRep.Create(new Hero("name1", 2));
        Assert.AreEqual(message, $"Successfully added hero name1 with level 2");

    }

    [Test]
    [TestCase(null)]
    [TestCase(" ")]
    [TestCase("")]
    public void TestIfRemoveMethodThrowsArgExcIfHEroNameIsNullOrWhitespace(string name)
    {
       
      Assert.Throws<ArgumentNullException>(() => heroRep.Remove(name));
       

    }


    [Test]
    public void TestIfRemoveMethodRemovesTheHero()
    {
        heroRep.Create(hero);
        heroRep.Remove("name");
        Assert.That(heroRep.Heroes.Count == 0);

    }
    [Test]
    public void TestIfRemoveMethodRemovesReturnsFalseIfHeroNotFound()
    {
        heroRep.Create(hero);
        //heroRep.Remove("dsdsds");
        Assert.IsFalse(heroRep.Remove("dsds"));

    }

    [Test]
    public void TestIfRemoveMethodRemovesReturnsTrue()
    {
        heroRep.Create(hero);
        //heroRep.Remove("dsdsds");
        Assert.IsTrue(heroRep.Remove("name"));

    }

    [Test]
    public void TestGetHeroWithHighestLevel()
    {
        heroRep.Create(hero);
        heroRep.Create(new Hero("name1", 100));
        heroRep.Create(new Hero("best", 155));
        Hero bestHeroResult = heroRep.GetHeroWithHighestLevel();
        Assert.AreEqual(bestHeroResult.Name, "best");
        Assert.AreEqual(bestHeroResult.Level, 155);
    
    }

    [Test]
    public void TestGetHeroReturnsTheCorrectHero()
    {
        heroRep.Create(hero);
        
        Hero bestHeroResult = heroRep.GetHero("name");
        Assert.AreEqual(bestHeroResult.Name, "name");
        Assert.AreEqual(bestHeroResult.Level, 1);
        Assert.AreEqual(bestHeroResult, hero);

    }
}
