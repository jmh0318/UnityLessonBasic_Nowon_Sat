﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_Classinheritance
{
    internal class Yellowman : Human
    {
        public override void Breath()
        {
            age++;
            height += 0.00097f;
            weight += 0.00088f;
        }
    }
}
