using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public interface IDomesticMammal : IAnimal
    {
        FurType FurType { get; set; }
    }

    public enum FurType
    {
        Long,
        Short,
        No
    }
}
