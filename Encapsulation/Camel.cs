using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Camel : Animal, ICarrying
    {
        public int HumpsNumber { get; set; }
        public float Payload { get; set; }
    }
}
