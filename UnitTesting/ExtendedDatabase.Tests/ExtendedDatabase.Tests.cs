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
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(16)]
        public void ConstructurShouldInitializeArrayWithElements(int count)
        {
            this.people = new Person[count];
            for (int i = 0; i < people.Length; i++)
            {
                Person current = new Person(i + 213, $"username{i}");
                people[i] = current;
            }
            data = new ExtendedDatabase.ExtendedDatabase(people);
            Assert.That(count == data.Count);
        }
        [Test]
        [TestCase(17)]
        public void ConstructorShouldThrowArgumentExpIfCountIsMoreThan16(int count)
        {
            this.people = new Person[count];
            for (int i = 0; i < people.Length; i++)
            {
                Person current = new Person(i + 213, $"username{i}");
                people[i] = current;
            }
            Assert.Throws<ArgumentException>(
                ()=>
                this.data = new ExtendedDatabase.ExtendedDatabase(people)
                );
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
        public void AddMethodShouldAddPersonInTheArray()
        {

            this.people = new Person[2] {pesho, gosho};
            Person newOne = new Person(545454, "Stamat");
            
            this.data = new ExtendedDatabase.ExtendedDatabase(people);
            data.Add(newOne);
            Person foundOne = data.FindById(545454);
            Assert.AreEqual(foundOne, newOne);
            Assert.That(data.Count == 3);
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

        [Test]
        public void RemoveMethodShouldThrowExceptionIfCountIs0()
        {
            this.people = new Person[1];
            for (int i = 0; i < people.Length; i++)
            {
                Person current = new Person(i + 213, $"username{i}");
                people[i] = current;
            }
            data = new ExtendedDatabase.ExtendedDatabase(people);
            data.Remove();
           
            

           
            Assert.Throws<InvalidOperationException>
                (() => data.Remove());
           


        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameShouldThrowArgumenExceptionIfNameIsNullOrEmpty(string name)
        {
          
            this.people = new Person[3];
            for (int i = 0; i < people.Length; i++)
            {
                Person current = new Person(i + 213, $"username{i}");
                people[i] = current;
            }
            data = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<ArgumentNullException>
                (() => data.FindByUsername(name),
                "Username parameter is null!"
                );
        }

        [Test]
        
        public void FindByUsernameShouldBeCaseSensitive()
        {

            this.people = new Person[2] { pesho, gosho};
           
            data = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>
                (() => data.FindByUsername(pesho.UserName.ToLower()),
                "No user is present by this username!"
                );
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionIfNoUsernameIsFound()
        {
            string name = "Stamat";
            this.people = new Person[3];
            for (int i = 0; i < people.Length; i++)
            {
                Person current = new Person(i + 213, $"username{i}");
                people[i] = current;
            }
            data = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>
                (() => data.FindByUsername(name),
                "No user is present by this username!"
                );
        }
        [Test]
        public void FindByUsernameShouldFindPersonByUsername()
        {
            string name = "Pesho";
            this.people = new Person[2] {pesho, gosho };
            
            data = new ExtendedDatabase.ExtendedDatabase(people);

            Person foundOne = data.FindByUsername(name);

            Person expectedResult = pesho;
            

            Assert.That(expectedResult, Is.EqualTo(foundOne));
           
        }
        [Test]
        public void FindByIdShouldThrowArgumentExceptionIfIdIsNegativeNum()
        {
            long ID = -1;
            this.people = new Person[3];
            for (int i = 0; i < people.Length; i++)
            {
                Person current = new Person(i + 213, $"username{i}");
                people[i] = current;
            }
            data = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<ArgumentOutOfRangeException>
                (() => data.FindById(ID),
                "Id should be a positive number!"
                );
        }

        [Test]
        public void FindByIdShouldThrowInvalidOperationExceptionIfIdIsNotFound()
        {
            long ID = 15;
            this.people = new Person[3];
            for (int i = 0; i < people.Length; i++)
            {
                Person current = new Person(i + 213, $"username{i}");
                people[i] = current;
            }
            data = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>
                (() => data.FindById(ID),
                "No user is present by this ID!"
                );
        }

        [Test]
        public void FindByIdShouldFindPersonWithProvidedId()
        {
            long ID = 156156;
            this.people = new Person[2] { pesho, gosho};
            
            data = new ExtendedDatabase.ExtendedDatabase(people);
            Person foundOne = data.FindById(156156);

            Person expectedResult = pesho;
            

            Assert.That(expectedResult, Is.EqualTo(foundOne));
        }

        [Test]
        [TestCase(1, "Pesho")]
        [TestCase(444, "Iva")]
        [TestCase(999, "Sxema")]
        [TestCase(444, "Rima")]
        [TestCase(111, "Yuna")]
        public void Person_SuccessfulDataPass(long id, string userName)
        {
            Person person = new Person(id, userName);
            long expectedId = id;
            long actualId = person.Id;
            string expectedUsername = userName;
            string actualUsername = person.UserName;

            Assert.AreEqual(expectedId, actualId);
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        //[Test]
        //public void ConstructorPersonShouldInitializeCollection()
        //{
        //    Assert.IsNotNull(pesho);
        //}

        [Test]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(22)]
        [TestCase(555)]
        [TestCase(100)]
        [TestCase(1000)]
        public void AddRange_Throws_ArgumentException_WhenCountMoreThan16(int count)
        {
            Person[] data = new Person[count];
            Assert.Throws<ArgumentException>
                (() => new ExtendedDatabase.ExtendedDatabase(data));
        }

        
        

    }
}