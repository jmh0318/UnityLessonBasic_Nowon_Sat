using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_Classinheritance
{
    internal class Dog : Creature , IFourLeggedWalker
    {
        public float tailLenght;

        public void FourLeggedWalker()
        {
            Console.WriteLine("네 발로 걷는다");
        }
    }
}
