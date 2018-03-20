using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatingTypes
{
    public abstract class Model : IEquatable<Model>
    {
        public int Id { get; set; }
        public bool Equals(Model other) => Id == other.Id;
        public IShop Shop { get; set; }
    }
}
