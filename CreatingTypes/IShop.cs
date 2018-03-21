using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingTypes
{
    public interface IShop
    {
        IReadOnlyList<Order> Orders { get; }
        IReadOnlyList<OrderProduct> OrderProducts { get; }
    }
}
