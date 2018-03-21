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
            shop.MakeOrder(a, new OrderProduct { Product = shop.Products[1], Amount = 1 }
                            , new OrderProduct { Product = shop.Products[0], Amount = 4 });
            shop.MakeOrder(b, new OrderProduct { Product = shop.Products[2], Amount = 3 }
                            , new OrderProduct { Product = shop.Products[1], Amount = 2 }).Status = OrderStatus.Purchased;
            return shop;
        }

        [TestMethod]
        public void Shop_FK_NoNullRefException()
        {
            Shop shop = Seed();
            Assert.AreEqual(shop, shop.Orders[0].OrderProducts[0].Product.OrderProducts[0].Order.Shop);
            Assert.AreEqual(shop, shop.Products[0].OrderProducts[0].Order.Shop);
            Assert.AreEqual(shop, shop.Customers[0].Orders[0].OrderProducts[0].Order.Customer.Orders[0]
                .OrderProducts[0].Order.Customer.Shop);
        }

        [TestMethod]
        public void Shop_OrderProductsAndTotalCost()
        {
            Shop shop = Seed();
            Assert.AreEqual("2, 1", string.Join(", ", shop.Orders[0].OrderProducts.Select(o => o.Product.Name)));
            Assert.AreEqual("@1", string.Join(", ", shop.Orders[0].Customer.Email));
            Assert.AreEqual(5.8m, shop.Orders[0].TotalCost);
        }

        [TestMethod]
        public void Shop_NoProduct_Exception()
        {
            Shop shop = Seed();
            Assert.ThrowsException<ArgumentException>(()
                => shop.MakeOrder(new Customer(), new OrderProduct { Product = new Product { Name = "New" } }));
        }

        [TestMethod]
        public void Shop_Empty_NoException()
        {
            Shop shop = new Shop();
            Assert.AreEqual("", string.Join(", ", shop.Customers.Select(c => c.Email)));
            Assert.AreEqual("", string.Join(", ", shop.Orders.SelectMany(o => o.OrderProducts).Select(o => o.Product.Name)));
            Assert.AreEqual("", string.Join(", ", shop.Products.Select(p => p.Name)));
            Assert.AreEqual("", string.Join(", ", shop.Products.SelectMany(p => p.OrderProducts).Select(o => o.Product.Name)));
        }

        [TestMethod]
        public void Shop_TotalCost()
        {
            Shop shop = new Shop();
            Assert.AreEqual(0m, shop.TotalCost);
            shop = Seed();
            Assert.AreEqual(8.5m, shop.TotalCost);
        }
    }
}
