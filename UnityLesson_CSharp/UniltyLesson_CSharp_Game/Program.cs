using System;
using System.Threading;

namespace UniltyLesson_CSharp_Game
{
    internal class Program
    {
        static Random random; // 말의 달리는 속도를 랜덤하게 생성하기 위한 변수
        static bool isGameFinished = false; // 경주가 끝났는지 체크하는 변수
        static int minSpeed = 10;
        static int maxSpeed = 20;
        static int finishDistance = 200;
        static void Main(string[] args)
        {
            Horse[] arr_horse = new Horse[5]; // 말 5마리 배열
            string[] arr_FinishedHorseName = new string[5]; // 결승선 통과한 말 5마리의 이름
            int currentGrade = 1; // 현재 등수

            // 말 생성 및 초기화
            int length = arr_horse.Length;
            for (int i = 0; i < length; i++)
            {
                arr_horse[i] = new Horse(); // 말 인스턴스화
                arr_horse[i].name = $"경주마{i + 1}"; // 말 이름 초기화
            }
            Console.WriteLine(" 시작하려면 엔터를 누르세요");
            Console.ReadLine();
            Console.WriteLine("경주 시작!");
            int count = 0;
            while (isGameFinished == false) // 게임 끝날때 까지 돌아가는 반복문
            {
                Thread.Sleep(1000);// 1초 지연시킬 수 있음
                count++;
                Console.WriteLine($"================================= {count} 초 ==================================");
                // 랜덤한 속도로 말을 달리는 반복문
                for (int i = 0; i < length; i++)
                {
                    if (arr_horse[i].available)
                    {
                        random = new Random();// 난수 인스턴스화
                        int tmpMoveDistance = random.Next(minSpeed, maxSpeed + 1);
                        arr_horse[i].Run(tmpMoveDistance); // i 번째 말을 10~20사이 거리만큼 움직임
                        Console.WriteLine($"{arr_horse[i].name} (이)가 달린거리 : {arr_horse[i].distance}");
                        // 결승전 도착 체크
                        if (arr_horse[i].distance >= finishDistance)
                        {
                            arr_FinishedHorseName[currentGrade - 1] = arr_horse[i].name;
                            arr_horse[i].available = false;
                            currentGrade++;
                        }
                    }
                }
                Console.WriteLine("===========================================================================");
                // 경주 끝났는지 체크 (모든 말이 들어왔는지)
                if (currentGrade > length)
                {
                    isGameFinished = true;
                    Console.WriteLine("경주 끝!");
                }
            }

            Console.WriteLine("================================ 결과 발표 ================================");
            for (int i = 0;i < length; i++)
            {
                Console.WriteLine($"{i + 1} 등 : {arr_FinishedHorseName[i]}");
            }
            Console.WriteLine("종료하려면 엔터를 누르세요");
            Console.ReadLine();
        }
    }
}