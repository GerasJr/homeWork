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
            bool isPlaying = true;
            int moveDirectionX = 0;
            int moveDirectionY = 0;

            Console.CursorVisible = false;
            ReadMap("map0", out map);
            DrawMap(map);

            while (isPlaying)
            {
                DirectionPlayer(ref moveDirectionX, ref moveDirectionY);
                MovePlayer(player, ref map, ref playerPositionX, ref playerPositionY, ref moveDirectionX, ref moveDirectionY);
            }
        }

        static void ReadMap(string mapName, out char[,] map)
        {
            string[] file = File.ReadAllLines($"Maps/{mapName}.txt");
            map = new char[file.Length, file[0].Length];
            
            for(int i = 0; i < map.GetLength(0); i++)
            {
                for(int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = file[i][j];
                }
            }
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }

        static void DirectionPlayer(ref int moveDirectionX,ref int moveDirectionY)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.W:
                    moveDirectionX = -1;
                    break;
                case ConsoleKey.A:
                    moveDirectionY = -1;
                    break;
                case ConsoleKey.S:
                    moveDirectionX = 1;
                    break;
                case ConsoleKey.D:
                    moveDirectionY = 1;
                    break;
            }
        }

        static void MovePlayer(char player, ref char[,] map, ref int positionX, ref int positionY, ref int directionX, ref int directionY)
        {
            if (map[positionX + directionX, positionY + directionY] != '#')
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
