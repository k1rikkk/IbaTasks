using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkFundamentals
{
    public class Employee : IComparable<Employee>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }

        public int CompareTo(Employee other) => Salary.CompareTo(other.Salary);
    }
}
