using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Dog : Animal, IDomesticMammal
    {
        public TrainedLevel TrainedLevel { get; set; }
        public FurType FurType { get; set; }
    }

    public enum TrainedLevel
    {
        Beginner,
        Intermediate,
        Advanced
    }
}
