using System;
using System.IO;

namespace hm32
{
    class HomeWork32
    {
        static void Main(string[] args)
        {
            char player = '@';
            char[,] map;
            int playerPositionX = 1;
            int playerPositionY = 1;

            Console.CursorVisible = false;
            LoadMap("map0" ,out map);
            PlayerMove(player , ref map, ref playerPositionX, ref playerPositionY);
        }

        static void LoadMap(string mapName, out char[,] map)
        {
            string[] file = File.ReadAllLines($"Maps/{mapName}.txt");
            map = new char[file.Length, file[0].Length];
            
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = file[i][j];
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }
        static void PlayerMove(char player, ref char[,] map, ref int positionX, ref int positionY)
        {
            bool isPlaying = true;
            int directionX = 0;
            int directionY = 0;

            while (isPlaying)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.W:
                        directionX = -1;
                        break;
                    case ConsoleKey.A:
                        directionY = -1;
                        break;
                    case ConsoleKey.S:
                        directionX = 1;
                        break;
                    case ConsoleKey.D:
                        directionY = 1;
                        break;
                }

                if(map[positionX + directionX, positionY + directionY] != '#')
                {
                    Console.SetCursorPosition(positionY, positionX);
                    Console.Write(' ');
                    positionX += directionX;
                    positionY += directionY;
                    Console.SetCursorPosition(positionY, positionX);
                    Console.Write(player);
                }

                directionX = 0;
                directionY = 0;
            }
        }
    }
}
