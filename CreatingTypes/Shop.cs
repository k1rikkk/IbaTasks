using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingTypes
{
    public class Shop : IShop
    {
        protected List<Customer> customers;
        protected List<Product> products;
        protected List<Order> orders;

        public IReadOnlyList<Customer> Customers => customers;
        public IReadOnlyList<Product> Products => products;
        public IReadOnlyList<Order> Orders => orders;

        public decimal TotalCost => orders.Where(o => o.Status == OrderStatus.Purchased).Sum(o => o.TotalCost);

        public Shop()
        {
            customers = new List<Customer>();
            products = new List<Product>();
            orders = new List<Order>();
        }

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException($"{nameof(product)}: product can\'t be null");
            if (products.Contains(product))
                return;
            product.Id = (products.Count == 0 ? 0 : products.Max(m => m.Id)) + 1;
            product.Shop = this;
            products.Add(product);
        }

        public void MakeOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException($"{nameof(order)}: order can\'t be null");
            if (order.Customer == null)
                throw new ArgumentNullException($"{nameof(order.Customer)}: customer can\'t be null");
            if (order.Product == null)
                throw new ArgumentNullException($"{nameof(order.Customer)}: product can\'t be null");
            if (!products.Contains(order.Product))
                throw new ArgumentException($"{nameof(order.Product)}: no such product in shop");
            if (order.Amount <= 0)
                throw new ArgumentException($"{nameof(order.Amount)}: amount must be positive");
            order.Id = (orders.Count == 0 ? 0 : orders.Max(o => o.Id)) + 1;
            order.Shop = this;
            AddCustomer(order.Customer);
            orders.Add(order);
        }

        protected void AddCustomer(Customer customer)
        {
            if (customers.Contains(customer))
                return;
            customer.Id = (customers.Count == 0 ? 0 : customers.Max(m => m.Id)) + 1;
            customer.Shop = this;
            customers.Add(customer);
        }
    }
}
