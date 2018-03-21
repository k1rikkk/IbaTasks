using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Chicken : Animal, IPoultry
    {
        public EggsLayingPeriod EggsLayingPeriod { get; set; }
        public float WingSpan { get; set; }
    }

    public enum EggsLayingPeriod
    {
        SummerOnly,
        AllTheYear
    }
}
