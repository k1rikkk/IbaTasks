using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingTypes
{
    public class OrderProduct : Model
    {
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Amount { get; set; }
        public decimal TotalCost => Amount * Product.Cost;
    }
}
