using System;
using System.Linq;
using CreatingTypes;
using Examples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CreatingTypesTest
    {
        private Shop Seed()
        {
            Shop shop = new Shop();
            shop.AddProduct(new Product { Name = "1", Cost = 1.1m });
            shop.AddProduct(new Product { Name = "2", Cost = 1.4m });
            shop.AddProduct(new Product { Name = "3", Cost = 1.9m });

            Customer a = new Customer { Email = "@1" };
            Customer b = new Customer { Email = "@2" };
            shop.MakeOrder(new Order { Product = shop.Products[1], Customer = a, Amount = 1 });
            shop.MakeOrder(new Order { Product = shop.Products[2], Customer = a, Amount = 3, Status = OrderStatus.Purchased });
            shop.MakeOrder(new Order { Product = shop.Products[1], Customer = b, Amount = 4 });
            return shop;
        }

        [TestMethod]
        public void Shop_FK()
        {
            Shop shop = Seed();
            Assert.AreEqual("2, 3", string.Join(", ", shop.Customers[0].Orders.Select(o => o.Product.Name)));
            Assert.AreEqual("@1, @2", string.Join(", ", shop.Products[1].Orders.Select(o => o.Customer.Email)));
        }

        [TestMethod]
        public void Shop_NoProduct_Exception()
        {
            Shop shop = Seed();
            Assert.ThrowsException<ArgumentException>(() 
                => shop.MakeOrder(new Order { Product = new Product { Name = "New" }, Customer = new Customer() }));
        }

        [TestMethod]
        public void Shop_Empty_NoException()
        {
            Shop shop = new Shop();
            Assert.AreEqual("", string.Join(", ", shop.Customers.Select(c => c.Email)));
            Assert.AreEqual("", string.Join(", ", shop.Orders.Select(o => o.Product.Name)));
            Assert.AreEqual("", string.Join(", ", shop.Products.Select(p => p.Name)));
            Assert.AreEqual("", string.Join(", ", shop.Products.SelectMany(p => p.Orders).Select(o => o.Product.Name)));
        }

        [TestMethod]
        public void Shop_TotalCost()
        {
            Shop shop = new Shop();
            Assert.AreEqual(0m, shop.TotalCost);
            shop = Seed();
            Assert.AreEqual(5.7m, shop.TotalCost);
        }
    }
}
