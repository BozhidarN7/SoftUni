namespace INStock
{
    using INStock.Contracts;
    using INStock.Models;
    using Moq;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mock<IProduct> product = new Mock<IProduct>();
            Mock<IProductStock> productStock = new Mock<IProductStock>();

            product.SetupGet(x => x.Label).Returns("Nuts");
            Console.WriteLine(product.Object.Label);
        }
    }
}

