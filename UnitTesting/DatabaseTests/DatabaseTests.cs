using NUnit.Framework;
using System;
using System.Linq;
using Database;


[TestFixture]
public class DatabaseTests
{
    [SetUp]
    public void SetUp()
    { 
    
    }

    [Test]
    public void ConstructorMustBeInitializedWith16Elements()
    {
        int[] numbers = Enumerable.Range(1,16).ToArray();
        Database.Database data = new Database.Database(numbers);

        Assert.AreEqual(data.Count,16);
    }

    //[Test]
    //public void ConstructorShouldThrowExceptionIfNot16Elements()
    //{
    //    int[] numbers = Enumerable.Range(1, 10).ToArray();
    //    Database.Database data = new Database.Database(numbers);

    //    var expectedRrsult = 16;
    //    var actualResult = data.Count;

    //    Assert.AreEqual(expectedRrsult, actualResult);


    //}


    [Test]
    public void ArrayCapacityMustBe16IntLong()
    {
        int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        Database.Database data = new Database.Database(array);
        Assert.Throws<InvalidOperationException>(
            ()=> data.Add(5), "Array's capacity must be exactly 16 integers!"
            );
    }

    [Test]
    public void AddMethodShoultAddElementAtTheNextFreeCell()
    {
        int[] numbers = Enumerable.Range(1, 10).ToArray();
        Database.Database data = new Database.Database(numbers);

        data.Add(5);
        var allElements = data.Fetch();

        var expectedValue = 5;
        var actualResult = allElements[10];

        Assert.AreEqual(expectedValue, actualResult);
    }


    [Test]
    public void RemoveOperationShoultRemoveElementAtTheLastIndex()
    {
        int[] numbers = Enumerable.Range(1, 10).ToArray();
        Database.Database data = new Database.Database(numbers);

        data.Remove();
        var allElements = data.Fetch();

        var expectedValue = 9;
        var actualResult = data.Fetch()[8];

        Assert.AreEqual(expectedValue, actualResult);
    }

    [Test]
    public void RemoveElementFromEmptyDatabaseShouldThrowException()
    {
        int[] numbers = new int[1] { 1};
        Database.Database data = new Database.Database(numbers);

        data.Remove();

        Assert.Throws<InvalidOperationException>(
            () => data.Remove(), "The collection is empty!"
            );
    }

    [Test]
    public void FetchShouldReturnAllElements()
    {
        int[] numbers = Enumerable.Range(1, 5).ToArray();
        Database.Database data = new Database.Database(numbers);

        var allElements = data.Fetch();
        int[] expectedResult = { 1, 2, 3, 4, 5 };
        CollectionAssert.AreEqual(expectedResult, allElements);
    }
}