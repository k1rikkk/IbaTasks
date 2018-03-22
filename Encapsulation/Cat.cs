using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Cat : Animal, IDomesticMammal
    {
        public bool CanCatchMice { get; set; }
        public FurType FurType { get; set; }
    }
}
