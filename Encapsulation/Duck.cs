﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Duck : Animal, IPoultry
    {
        public bool CanFly { get; set; }
        public float WingSpan { get; set; }
    }
}
