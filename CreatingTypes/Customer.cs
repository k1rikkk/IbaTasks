using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingTypes
{
    public class Customer : Model
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public List<Order> Orders => Shop?.Orders.Where(o => o.Customer.Equals(this)).ToList() ?? new List<Order>();
    }
}
