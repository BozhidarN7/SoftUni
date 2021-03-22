using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private const int arrayCapacity = 16;
        private Database database;
        private Database databaseWithOneElement;

        [SetUp]
        public void Setup()
        {
            database = new Database(1, 2, 3, 4, 5);
            databaseWithOneElement = new Database(1);
        }

        [Test]
        public void When_AddMethodCall_ShouldAddElementAtTheEnd()
        {
            int newElement = 6;
            int numberOfElement = database.Count;
            database.Add(newElement);

            Assert.That(database.Count, Is.EqualTo(numberOfElement + 1));
        }
        [Test]
        public void When_AddMethodCall_ShouldThrowExeptionIFCapacityPassed()
        {
            for (int i = 1; i < arrayCapacity; i++)
            {
                databaseWithOneElement.Add(i + 1);
            }

            Assert.That(() => databaseWithOneElement.Add(5), Throws
                .InvalidOperationException
                .With
                .Message
                .EqualTo("Array's capacity must be exactly 16 integers!"));
        }
        [Test]
        public void When_RemoveMethodCall_ShouldRemoveElement()
        {
            int numberOfElements = database.Count;
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(numberOfElements - 1));
        }
        [Test]
        public void When_RemoveMethodCall_ShouldThrowExceptionIfElementsAreZero()
        {
            databaseWithOneElement.Remove();
            Assert.That(() => databaseWithOneElement.Remove(), Throws.
                InvalidOperationException
                .With
                .Message
                .EqualTo("The collection is empty!"));
        }
        [Test]
        public void When_FetchMethodCall_ShouldReturnAllElements()
        {
            int[] elements = new int[] { 1, 2, 3, 4, 5 };

            CollectionAssert.AreEqual(database.Fetch(), elements);
        }
        [Test]
        public void WhenConstructorInvolve_ShouldCreateArray()
        {
            int[] elements = new int[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(new Database(elements).Fetch(), elements);
        }
    }
}