using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingTypes
{
    public class Shop : Model
    {
        protected List<Customer> customers;
        protected List<Product> products;
        protected List<Order> orders;

        public IReadOnlyList<Customer> Customers => customers;
        public IReadOnlyList<Product> Products => products;
        public IReadOnlyList<Order> Orders => orders;

        public Shop()
        {
            customers = new List<Customer>();
            products = new List<Product>();
            orders = new List<Order>();
        }

        public void AddProduct(Product product)
        {
            if (products.Contains(product))
                return;
            product.Id = customers.Max(m => m.Id) + 1;
            product.Shop = this;
            products.Add(product);
        }

        public void Order(Order order)
        {
            if (!products.Contains(order.Product))
                throw new ArgumentException($"{nameof(order.Product)}: no such product in shop");
            if (order.Customer == null)
                throw new ArgumentNullException($"{nameof(order.Customer)}: customer can\'t be null");
        }

        public void RemoveCustomer(Customer customer)
        {
            if (customers.Contains(customer))
                customers.Remove(customer);
        }
    }
}
