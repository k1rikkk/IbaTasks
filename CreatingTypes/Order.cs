using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingTypes
{
    public class Order : Model
    {
        public Customer Customer { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
        public decimal TotalCost => OrderProducts.Sum(o => o.TotalCost);
        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus
    {
        Ordered,
        Purchased
    }
}
