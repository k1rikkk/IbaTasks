using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingTypes
{
    public class Product : Model
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public decimal Cost { get; set; }

        public List<Order> Orders => Shop.Orders.Where(o => o.Product.Equals(this)).ToList();
    }
}
