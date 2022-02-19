using System;
using System.Collections.Generic;

namespace UnityLesson_CSharp_Classinheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Creature creature = new Creature();
            for (int i = 0; i < 10; i++)
            {
                creature.Breath();
            }
            Console.WriteLine(creature.age);

            Human human = new Human();
            for (int i = 0; i < 10; i++)
            {
                human.Breath();
            }
            Console.WriteLine($"age : {human.age}, height : {human.height}, weight : {human.weight}");

            Dog dog = new Dog();
            dog.tailLenght = 1f;

            // 각 인종 20명, 두 발로 걷기
            //======================================================================
            // case : 각 인종에 대한 리스트 별개로 생성하기
            List<whiteman> whiteMen = new List<whiteman>();
            List<Blackman> blackMen = new List<Blackman>();
            List<Yellowman> yellowMen = new List<Yellowman>();
            for (int i = 0; i < 20; i++)
            {
                whiteman tmpMan = new whiteman();
                whiteMen.Add(tmpMan);
            }
            for (int i = 0; i < 20; i++)
            {
                Blackman tmpMan = new Blackman();
                blackMen.Add(tmpMan);
            }
            for (int i = 0; i < 20; i++)
            {
                Yellowman tmpMan = new Yellowman();
                yellowMen.Add(tmpMan);
            }

            foreach (var item in whiteMen)
            {
                item.TwoLeggedWalk();
            }
            foreach (var item in blackMen)
            {
                item.TwoLeggedWalk();
            }
            foreach (var item in yellowMen)
            {
                item.TwoLeggedWalk();
            }

            // WhiteMan 객체화 -> Human 으로 인스턴스화
            // Human변수에 있는 Breath 를 호출하면 WhiteMan 에 있는 Breath 가 호출됨
            // 
            // 자식 객체를 부모 클래스타입으로 인스턴스화 시키고
            // 해당 변수의 virtual 멤버 함수를 호출하면
            // 자식 객체의 override 된 함수가 호출된다.
            Human testHuman = new Human();
            testHuman.Breath();
            Console.WriteLine($"{testHuman.height}{testHuman.weight}");

            // case : 위 성질을 이용하여 부모클래스(Human) 리스트 하나만 생성
            List<Human> humen = new List<Human>();
            for (int i = 0; i < 20; i++)
            {
                Human tmpHuman1 = new whiteman();
                humen.Add(tmpHuman1);
                Human tmpHuman2 = new Blackman();
                humen.Add(tmpHuman2);
                Human tmpHuman3 = new Yellowman();
                humen.Add(tmpHuman3);
            }
            foreach (var item in humen)
            {
                item.TwoLeggedWalk();
            }

            // 인터페이스로 인스턴스화 시키는 방법
            ITwoLeggedWalker iTwoLeggedWalker = new whiteman();
            iTwoLeggedWalker.TwoLeggedWalk();
            // case : 인터페이스를 인스턴스화 시키는 방법
            List<ITwoLeggedWalker> walkers = new List<ITwoLeggedWalker>();
            for (int i = 0; i < 20; i++)
            {
                ITwoLeggedWalker tmpWalker1 = new whiteman();
                walkers.Add(tmpWalker1);
                ITwoLeggedWalker tmpWalker2 = new Blackman();
                walkers.Add(tmpWalker2);
                ITwoLeggedWalker tmpWalker3 = new Yellowman();
                walkers.Add(tmpWalker3);
            }
            foreach (var item in walkers)
            {
                item.TwoLeggedWalk();
            }
        }
    }
}