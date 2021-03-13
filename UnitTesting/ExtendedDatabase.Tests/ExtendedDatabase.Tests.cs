using NUnit.Framework;
using ExtendedDatabase;
using System;
using System.Linq;

namespace Tests
{
    public class ExtendedDatabaseTests
    {

        private Person pesho;
        private Person gosho;
        private Person[] people;
        private ExtendedDatabase.ExtendedDatabase data;

        [SetUp]
        
        public void Setup()
        {
            pesho = new Person(156156, "Pesho");
            gosho = new Person(5465486, "Gosho");

        }

        [Test]
        public void ConstructurShouldInitializeArrayWithElements()
        {
            this.people = new Person[16];
            for (int i = 0; i < people.Length; i++)
            {
                Person current = new Person(i + 213, $"username{i}");
                people[i] = current;
            }
            data = new ExtendedDatabase.ExtendedDatabase(people);
            Assert.That(16 == data.Count);
        }
        [Test]
        public void AddMethodShouldAddElementIfCapacityIsLessThan16()
        {

            this.people = new Person[16];
            for (int i = 0; i < people.Length; i++)
            {
                Person current = new Person(i + 213, $"username{i}");
                people[i] = current;
            }
            Person newone = new Person(548484, "17thPerson");
            Assert.Throws<InvalidOperationException>(
                () => data.Add(newone), "Array's capacity must be exactly 16 integers!"
                ) ;
        }

        [Test]
        public void AddMethodShouldAddPersonWithUniqueID()
        {

            this.people = new Person[2];
            people[0] = gosho;
            people[1] = pesho;
            this.data = new ExtendedDatabase.ExtendedDatabase(people);
            Person duplicateIDPerson = new Person(5465486, "Ivan");
            Assert.Throws<InvalidOperationException>(
                () => data.Add(duplicateIDPerson), "There is already user with this Id!"
                );
        }

        [Test]
        public void AddMethodShouldAddPersonWithUniqueUsername()
        {

            this.people = new Person[2];
            people[0] = gosho;
            people[1] = pesho;
            this.data = new ExtendedDatabase.ExtendedDatabase(people);
            Person duplicateIDPerson = new Person(4343, "Pesho");
            Assert.Throws<InvalidOperationException>(
                () => data.Add(duplicateIDPerson), "There is already user with this username!"
                );
        }

        [Test]
        public void AddRangeShouldAcceptNoMoreThan16People()
        {
            this.people = new Person[17];
            for (int i = 0; i < people.Length; i++)
            {
                Person current = new Person(i + 213, $"username{i}");
                people[i] = current;
            }
            Assert.Throws<ArgumentException>(
                () => this.data = new ExtendedDatabase.ExtendedDatabase(people), 
                "Provided data length should be in range [0..16]!"
                );
        }

        [Test]
        public void AddRangeShouldInitializeDataWithPeople()
        {
            this.people = new Person[10];
            for (int i = 0; i < people.Length; i++)
            {
                Person current = new Person(i + 213, $"username{i}");
                people[i] = current;
            }
            this.data = new ExtendedDatabase.ExtendedDatabase(people);

            int actualResult = data.Count;
            int expectedResult = 10;

            Assert.That(actualResult == expectedResult);
        }

        [Test]
        public void RemoveMethodShouldRemoveOnePerson()
        {
            this.people = new Person[3];
            for (int i = 0; i < people.Length; i++)
            {
                Person current = new Person(i + 213, $"username{i}");
                people[i] = current;
            }
            data = new ExtendedDatabase.ExtendedDatabase(people);
            data.Remove();

            
            var actualResult = data.Count;

            Assert.That(actualResult == 2);
            Assert.Throws<InvalidOperationException>
                (() => data.FindById(people.Length + 213));
            Assert.Throws<InvalidOperationException>
                (() => data.FindByUsername("username2"));


        }


    }
}