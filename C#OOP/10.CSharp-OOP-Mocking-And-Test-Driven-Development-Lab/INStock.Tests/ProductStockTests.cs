namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class ProductStockTests
    {
        Mock<IProduct> product;
        IProductStock productStock;
        [SetUp]
        public void Setup()
        {
            product = new Mock<IProduct>();
            product.SetupGet(x => x.Label).Returns("Nuts");
            product.SetupGet(x => x.Price).Returns(2m);
            product.SetupGet(x => x.Quantity).Returns(1);
            productStock = new ProductStock();
        }
        [Test]
        public void When_AddCall_ShouldAddProduct()
        {
            int count = productStock.Count;
            productStock.Add(product.Object);
            Assert.AreEqual(productStock.Count, count + 1);
        }
        [Test]
        public void When_ContainsCall_ShouldReturnTrueIfContains()
        {
            productStock.Add(product.Object);
            Assert.That(productStock.Contains(product.Object));
        }
        [Test]
        public void WhenFindCall_ShouldReturnProduct()
        {
            productStock.Add(product.Object);
            Assert.AreEqual(productStock.Find(0), product.Object);
        }
    }
}
