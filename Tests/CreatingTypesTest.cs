using System;
using CreatingTypes;
using Examples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CreatingTypesTest
    {
        [TestMethod]
        public void Smth()
        {
            Shop shop = new Shop();
            shop.AddProduct(new Product { Name = "1" });
            shop.AddProduct(new Product { Name = "2" });
            shop.AddProduct(new Product { Name = "3" });
            Customer a = new Customer { Email = "@1" };
            Customer b = new Customer { Email = "@2" };
            shop.Order(new Order { Product = shop.Products[1], Customer = a, Amount = 1 });
            shop.Order(new Order)
        }
    }
}
