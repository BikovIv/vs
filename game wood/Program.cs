using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace game_wood
{
    class Program
    {
        static int playerPositionX = 0;
        static int playerPositionY = 0;
        static int playerSize = 1;
        static int monsterPositionX = 0;
        static int monsterPositionY = 0;
        static int monsterSize = 1;
        static Random randomGenerator = new Random();
        static int doorPositionX = Console.WindowWidth - 80;
        static int doorPositionY = Console.WindowHeight - 2;
        static int doorSizeY = Console.WindowWidth - 3;
        static int doorSizeX = Console.WindowHeight - 2;
        static int woodPosition = Console.WindowWidth/2;
        static int woodSize = 0;

        static void DrawPlayer()
        {
            for (int x = playerPositionX; x < playerPositionX + playerSize; x++)
            {
                int y = playerPositionY;
                PrintAtPosition(x, y, '*');
            }
        }
        static void DrawDoor()
        {
            for (int x = doorPositionX; x < doorPositionX + doorSizeY; x++)
            {
                int y = doorPositionY;
                PrintAtPosition(x, y, '>');
            }
        }
        static void SetPositions()
        {
            playerPositionX = 0;
            monsterPositionY = Console.WindowWidth / 2 - 20;
            monsterPositionX = Console.WindowHeight / 2 + 60;
        }
        static void PrintAtPosition(int x, int y, char symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }
        static void DrawWood()
        {           
            int x = 1;
            for(int y=0;y<=Console.WindowHeight/2+9;y++) {
                PrintAtPosition(x, y, '|');               
            }
            x = x + 1;
            for (int y =0;y<Console.WindowHeight/2+10;y++) {
                PrintAtPosition(x, y, '/');
            }
            x = x + 1;
            for (int y = 0; y < Console.WindowHeight / 2 + 10; y++)
            {
                PrintAtPosition(x, y, '|');
            }
            
          //x = x + 7;
          // for (int y = Console.WindowHeight - 8; y < Console.WindowHeight / 2 + 10; y++)
          //  {
          //      PrintAtPosition(x, y, '|');
          //      x+=2;
          //  }
          // x = 4;
          //  for (int y = Console.WindowHeight/2 ; y < Console.WindowHeight / 2 + 4; y++)
          //  {
          //     PrintAtPosition(x, y, '|');
          //      x++;
          // }
            x = Console.WindowWidth/2-24;           
            for (int y = Console.WindowHeight-14; y < Console.WindowHeight / 2 + 10; y++)
            {
                PrintAtPosition(x, y, '|');
                x-- ;
            }
            x = Console.WindowWidth / 2 - 20;
            for (int y = Console.WindowHeight - 14; y < Console.WindowHeight / 2 + 10; y++)
            {
                PrintAtPosition(x, y, '|');
                x++;
            }
            
            //x = Console.WindowHeight-6;
            //for (int y = Console.WindowHeight - 10; y < Console.WindowHeight / 2 + 10; y++)
            //{
            //    PrintAtPosition(x, y, '|');
            //    x--;
            //}


        }
        static void DrawMonster()
        {
            for (int x = monsterPositionX; x < monsterPositionX + monsterSize; x++)
            {
                int y = monsterPositionY;
                PrintAtPosition(x, y, '#');
                //PrintAtPosition(x-5, y-9, '#');
            }
        }
        static void RemooveScroll()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }
        static void MoovePlayerRight()
        {
            if (playerPositionX < Console.WindowWidth - 1)
            {
                playerPositionX++;
            }
        }
        static void MoovePlayerLeft()
        {
            if (playerPositionX > 0 )
            {
                playerPositionX--;
            }
        }
        static void MovePlayerUp()
        {
            if (playerPositionY > 0)
            {
                playerPositionY--;
            }
        }
        static void MovePlayerDown()
        {
            if (playerPositionY <= Console.WindowHeight - 4 || playerPositionX > Console.WindowWidth - 4 )
            {
                playerPositionY++;
            }
        }
        static void MoveMonster()
        {
            int randomNumber = randomGenerator.Next(0, 5);
            if (randomNumber == 0)
            {
                MoveMonsterUp();
            }
            if (randomNumber == 1)
            {
                MoveMonsterLeft();
            }
            if (randomNumber == 2)
            {
                MoveMonsterRight();
            }
            if (randomNumber == 3)
            {
                MoveMonsterDown();
            }
            if (randomNumber == 4)
            {
                MoveMonsterLeft();
            }
        }
        static void MoveMonsterDown()
        {
            if (monsterPositionY < Console.WindowHeight - 1)
            {
                monsterPositionY++;
            }
        }
        static void MoveMonsterRight()
        {
            if (monsterPositionX < Console.WindowWidth - 1)
            {
                monsterPositionX++;
            }
        }
        static void MoveMonsterLeft()
        {
            if (monsterPositionX > 0)
            {
                monsterPositionX--;
            }
        }
        static void MoveMonsterUp()
        {
            if (monsterPositionY > 0)
            {
                monsterPositionY--;
            }
        }
        static void Main(string[] args)
        {
            RemooveScroll();
            SetPositions();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        MoovePlayerRight();
                    }
                    if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        MoovePlayerLeft();
                    }
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        MovePlayerUp();
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        MovePlayerDown();
                    }
                }
                if (playerPositionX == monsterPositionX && playerPositionY == monsterPositionY)
                {
                    Console.WriteLine("Game over!!!");
                    break;
                }
                if (playerPositionY >= Console.WindowHeight)
                {
                    Console.WriteLine("You beat level 1!!!");
                    break;
                }
                MoveMonster();
                Console.Clear();
                DrawPlayer();
                DrawDoor();
                DrawMonster();
                DrawWood();
                Thread.Sleep(20);
            }
        }
    }
}


