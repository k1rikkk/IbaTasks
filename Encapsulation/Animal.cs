using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public abstract class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Mass { get; set; }
        public string Breed { get; set; }
    }
}
