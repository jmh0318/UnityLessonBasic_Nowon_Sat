using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_Classinheritance
{
    internal class Blackman : Human
    {
        public override void Breath()
        {
            age++;
            height += 0.0005f;
            weight += 0.00049f;
        }
    }
}
