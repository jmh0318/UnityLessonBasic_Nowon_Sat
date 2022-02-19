using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLesson_CSharp_Classinheritance
{
    internal class Human : Creature, ITwoLeggedWalker
    {
        public float height;

        // override : 부모의 virtual 키워드가 붙은 함수를 재정의 하는 키워드
        public override void Breath()
        {
            base.Breath(); // 부모내용 받고싶을때만 쓰자...
            height += 0.00004f;
            weight += 0.00002f;
        }

        public void TwoLeggedWalk()
        {
            Console.WriteLine("두 발로 걷는다");
        }
    }
}
