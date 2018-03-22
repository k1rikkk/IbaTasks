using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public abstract class Animal : IAnimal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
    }
}
