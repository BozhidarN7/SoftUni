using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private const int MaxCapicty = 16;
        private ExtendedDatabase database;
        [SetUp]
        public void Setup()
        {
            database = new ExtendedDatabase();
        }

        [Test]
        public void When_ConstructorInvolve_ShouldCreatePersonArray()
        {
            Person personOne = new Person(1, "Username1");
            Person personTwo = new Person(2, "Username2");
            Person[] personArray = new Person[] { personOne, personTwo };
            Assert.AreEqual(new ExtendedDatabase(
                personOne, personTwo).Count, personArray.Length);
        }
        [Test]
        public void When_CtroInvolveAndCapacityExceeded_ShouldThrowException()
        {
            Person[] people = new Person[MaxCapicty + 1];
            for (int i = 0; i < MaxCapicty; i++)
            {
                database.Add(new Person(i, $"Username{i}"));
            }
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(people));
        }
        [Test]
        public void When_PersonIsAdded_ShouldCountIncrement()
        {
            int numberOfPeople = database.Count;
            database.Add(new Person(1, "Test"));

            Assert.That(database.Count, Is.EqualTo(numberOfPeople + 1));
        }
        [Test]
        [TestCase(1, "Test1", 2, "Test1")]
        [TestCase(1, "Test1", 1, "Test2")]
        public void When_AddDuplicateIdOrName_ShouldThrowExceptoin(int firstId
            , string firstName, int secondId, string secondName)
        {
            database.Add(new Person(firstId, firstName));
            Assert.Throws<InvalidOperationException>(() => database
            .Add(new Person(secondId, secondName)));
        }

        [Test]
        public void When_AddCallExceedCapacity_ShouldThrowException()
        {
            for (int i = 0; i < MaxCapicty; i++)
            {
                database.Add(new Person(i, $"usernmae{i}"));
            }
            Assert.Throws<InvalidOperationException>(() => database
            .Add(new Person(214, "Test214")));
        }
        [Test]
        public void When_RemoveCallWithZeroElements_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void When_RemoveCall_ShouldDecreaseCount()
        {
            database.Add(new Person(1, "Test"));
            int count = database.Count;
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(count - 1));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void When_FindByNameCallWithInvalidName_ShuoldThrowException(
            string name)
        {
            Assert.Throws<ArgumentNullException>(() => database.
            FindByUsername(name));
        }
        [Test]
        public void When_FindByNameCallWithNotPresentedName_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => database
            .FindByUsername("Test"));
        }
        [Test]
        public void When_FindByUsernameCall_ShouldReturnPersonWithProvidedName()
        {
            Person person = new Person(1, "Test");
            database.Add(person);
            Assert.That(() => database.FindByUsername(person.UserName)
            , Is.EqualTo(person));
        }

        [Test]
        public void When_FindByIdCallWithInvalidId_ShouldThrowException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>database
                .FindById(-5));
        }
        [Test]
        public void When_FindByIdCallWithNoSuchId_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => database
            .FindById(5));
        }
        [Test]
        public void When_FindByIdCallWith_ShouldReturnPersonWidhtGivenId()
        {
            Person person = new Person(1, "Test");
            database.Add(person);
            Assert.That(database.FindById(person.Id), Is.EqualTo(person));
        }
    }
}