using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Boy : Human
    {
        public bool? IsSuitableForArmy { get; protected set; } = null;
        public override string Introduction => "Handshake";
        public override string ToString() => $"Boy: {FullName}";

        public virtual void PassMedicalExamination()
        {
            if (!IsSuitableForArmy.HasValue)
                IsSuitableForArmy = new Random().Next(2) == 1;
        }
    }
}
