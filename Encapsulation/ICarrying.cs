﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public interface ICarrying : IAnimal
    {
        float Payload { get; set; }
    }
}
