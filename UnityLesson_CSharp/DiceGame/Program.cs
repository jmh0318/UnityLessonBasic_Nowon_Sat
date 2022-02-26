using System;
using System.Collections.Generic;
namespace DiceGame
{
    internal class Program
    {
        static private int totalTile = 20; // 칸의 개수
        static private int totalDiceNumber = 20; // 총 주사위 갯수
        static private Random random;
        static void Main(string[] args)
        {
            int previousTileIndex = 0; // 이전 칸의 인덱스
            int currentTileIndex = 0; // 현재 칸의 인덱스
            int currentStarPoint = 0; // 현재 샛별 점수

            TileMap map = new TileMap();
            map.MapSetup(20); // 맵 생성

            int currentDiceNum = totalDiceNumber;
            // 주사위 게임 시작
            while (currentDiceNum > 0)
            {
                int diceValue = RollaDice(); // 주사위 굴리기
                currentDiceNum--; // 주사위 굴렸으니까 남은 주사위갯수 차감
                currentTileIndex += diceValue; // 플레이어 주사위 눈금만큼 전진

                // 현재칸이 최대칸을 넘어가버렸을때
                if(currentTileIndex > totalTile)
                {
                    currentTileIndex -= totalTile;
                }

                Console.WriteLine($"현재 플레이어 위치 {currentTileIndex}");

                // 플레이어가 샛별칸을 몇 개 지났는지 체크
                int passedStarTileNum = currentTileIndex / 5 - previousTileIndex / 5;
                if (passedStarTileNum > 1)
                {
                    for (int i = 0; i < passedStarTileNum; i++)
                    {
                        int starTileindex = (currentTileIndex / 5 - i )* 5;

                        if(starTileindex > totalTile)
                           starTileindex -= totalTile;

                        TileInfo_Star tileInfo_Star = (TileInfo_Star)map.mapInfo.GetValueOrDefault(starTileindex); // 또는 뒤에 as TileInfo_Star 붙이기
                        if (tileInfo_Star != null)
                        {
                            currentStarPoint += tileInfo_Star.starValue;
                        }
                    }
                    
                }
                // 현재 칸의 정보 받아옴
                TileInfo info = map.mapInfo.GetValueOrDefault(currentTileIndex);
                if (info == null)
                {
                    Console.WriteLine($"Failed to get tileinfo. num : {currentTileIndex}");
                    return;
                }
                info.TileEvent(); // 칸의 이벤트호출

                previousTileIndex = currentTileIndex;
                Console.WriteLine($"현재 샛별 점수 : {currentStarPoint}");
                Console.WriteLine($"남은 주사위 갯수 : {currentDiceNum}");
            }
            Console.WriteLine($"Game Finished ! You got total {currentStarPoint} stars");
        }
        static int RollaDice()
        {
            string userInput = "Default";
            while (userInput != "")
            {
                Console.WriteLine("Roll a Dice ! Press Enter");
                userInput = Console.ReadLine();
            }
            random = new Random();
            int diceValue = random.Next(1, 7);
            Console.WriteLine($"DiceValue : {diceValue}");
            DisplayDice(diceValue);
            return diceValue;
        }

        static void DisplayDice(int diceValue)
        {
            switch (diceValue)
            {
                case 1:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│     ●    │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("└───────────┘");
                    break;
                case 2:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●        │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│         ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 3:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●        │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│     ●    │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│         ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 4:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 5:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│     ●    │");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                case 6:
                    Console.WriteLine("┌───────────┐");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("│           │");
                    Console.WriteLine("│ ●      ●│");
                    Console.WriteLine("└───────────┘");
                    break;
                default:
                    break;
            }
        }
        
    }
}