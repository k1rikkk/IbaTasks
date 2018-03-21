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
        protected List<OrderProduct> orderProducts;

        public IReadOnlyList<Customer> Customers => customers;
        public IReadOnlyList<Product> Products => products;
        public IReadOnlyList<Order> Orders => orders;
        public IReadOnlyList<OrderProduct> OrderProducts => orderProducts;

        public decimal TotalCost => Orders.Where(o => o.Status == OrderStatus.Purchased).Sum(o => o.TotalCost);

        public Shop()
        {
            customers = new List<Customer>();
            products = new List<Product>();
            orders = new List<Order>();
            orderProducts = new List<OrderProduct>();
        }

        public void AddProduct(Product product)
        {
            if (products.Contains(product))
                return;
            product.Id = products.Count == 0 ? 0 : products.Max(m => m.Id) + 1;
            product.Shop = this;
            products.Add(product);
        }

        private void AddCustomer(Customer customer)
        {
            if (customers.Contains(customer))
                return;
            customer.Id = customers.Count == 0 ? 0 : customers.Max(c => c.Id) + 1;
            customer.Shop = this;
            customers.Add(customer);
        }

        public Order MakeOrder(Customer customer, params OrderProduct[] orderProducts)
        {
            if (customer == null)
                throw new ArgumentNullException($"{nameof(customer)}: customer can\'t be null");
            if ((orderProducts == null) || (orderProducts.Any(o => o == null)))
                throw new ArgumentNullException($"{nameof(orderProducts)}: products can\'t be null");
            if (orderProducts.Any(o => o.Amount <= 0))
                throw new ArgumentException($"{nameof(orderProducts)}: all amounts must be positive");
            Order order = new Order
            {
                Id = orders.Count == 0 ? 0 : orders.Max(o => o.Id) + 1,
                Customer = customer,
                Shop = this,
                OrderProducts = new List<OrderProduct>(orderProducts)
            };
            AddCustomer(customer);
            this.orderProducts.AddRange(orderProducts);
            int mid = this.orderProducts.Max(o => o.Id) + 1;
            for (int i = 0; i < orderProducts.Count(); i++)
            {
                orderProducts[i].Id = mid + i;
                orderProducts[i].Shop = this;
                orderProducts[i].Order = order;
            }
            orders.Add(order);
            return order;
        }
    }
}
