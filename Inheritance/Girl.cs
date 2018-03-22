using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Girl : Human
    {
        public virtual bool Rouged { get; set; }
        public override string Introduction => "Hangs";
        public override string ToString() => $"Girl: {FullName}";
    }
}
