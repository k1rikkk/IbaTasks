using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingTypes
{
    public class Order : Model
    {
        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public int Amount { get; set; }
        public OrderStatus Status { get; set; }

        public decimal TotalCost => Amount * Product?.Cost ?? 0m;
    }

    public enum OrderStatus
    {
        Ordered, 
        Purchased
    }
}
