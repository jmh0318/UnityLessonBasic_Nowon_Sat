using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniltyLesson_CSharp_Game
{
    internal class Horse
    {
        public bool available = true;
        public string name;
        public int distance;
        public void Run(int moveDistance)
        {
            distance += moveDistance;
        }
    }
}
