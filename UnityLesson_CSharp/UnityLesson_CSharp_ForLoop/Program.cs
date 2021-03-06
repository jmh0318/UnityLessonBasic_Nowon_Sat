using System;

namespace UnityLesson_CSharp_ForLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // for문
            // 기본형태
            /*for (인덱스용 변수 선언 및 초기화; for문을 실행할 조건; 루프가 한번 실행될때마다 마지막에 실행할 문장)
            {
                반복수행시 실행할 내용
            }*/

            string[] arr_PersonName = new string[9];
            arr_PersonName[0] = "김승태";
            arr_PersonName[1] = "김응태";
            arr_PersonName[2] = "김승래";
            arr_PersonName[3] = "김승태";
            arr_PersonName[4] = "김응태";
            arr_PersonName[5] = "김승래";
            arr_PersonName[6] = "김승태";
            arr_PersonName[7] = "김응태";
            arr_PersonName[8] = "김승래";

            int length = arr_PersonName.Length;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(arr_PersonName[i]);
            }

            // 김승태만 출력을 하고싶다. 김승태의 인덱스 규칙은 : 3n
            // ===========================================
            // 모든 배열 요소를 검색하는 예시
            for (int i = 0; i < length; i++)
            {
                if(arr_PersonName[i] == "김승태")
                {
                    Console.WriteLine(arr_PersonName[i]);
                }
            }
            // 인덱스 규칙을 활용한 예시
            for (int i = 0; i < length; i += 3)
            {
                Console.WriteLine(arr_PersonName[i]);
            }
        }
    }
}
