using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace main_1
{
    public class Task45 : ITask
    {
        private readonly Random _random = new Random();
        private const int Width = 20;
        private const int Height = 10;

        private const char BorderMap = '#';
        private const char EmptyMap = ' ';
        private const char Player = 'P';
        private const char ExpPoint = '*';

        // mvp квадрат с точками очками которые просто спауняться и игрок их собирает
        // алгоритм генерируемых лабиринтов (с очками и препятсвиями возможно)
        // квадратная сетка, точки спауна по углам, выход всегда в противоположной стороне

        public void Run()
        {
            char[,] mapGen = GenerationMap();
            (int heightPosition, int widthPosition) playerPosition = (Height/2-1, Width/2-1);
            mapGen[playerPosition.heightPosition, playerPosition.widthPosition] = Player;
            GenerateExpPoint(mapGen);

            int score = 0;
            bool isRunning = true;

            while (isRunning)
            {
                PrintMap(mapGen, score);
                var key = Console.ReadKey(true).Key;
                (int heightPosition, int widthPosition) newPosition = playerPosition;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        newPosition.heightPosition--;
                        break;
                    case ConsoleKey.DownArrow:
                        newPosition.heightPosition++;
                        break;
                    case ConsoleKey.LeftArrow:
                        newPosition.widthPosition--;
                        break;
                    case ConsoleKey.RightArrow:
                        newPosition.widthPosition++;
                        break;
                    case ConsoleKey.Escape:
                        isRunning = false;
                        break;
                }

                if (CheckPosition(ref mapGen, newPosition, ref score))
                {
                    mapGen[playerPosition.heightPosition, playerPosition.widthPosition] = EmptyMap;
                    playerPosition = newPosition;
                    mapGen[playerPosition.heightPosition, playerPosition.widthPosition] = Player;
                }                
            }

            Console.Clear();
            Console.WriteLine($"Score: {score}\n");
            Console.WriteLine("Exiting the program.");
        }

        private bool CheckPosition(ref char[,] map, (int heightPosition, int widthPosition) position, ref int score)
        {
            if (map[position.heightPosition, position.widthPosition] != BorderMap)
            {
                if (map[position.heightPosition, position.widthPosition] == ExpPoint)
                {
                    score++;
                    GenerateExpPoint(map);
                }
                return true;
            }

            return false;
        }

        private void GenerateExpPoint(char[,] map)
        {
            int x, y;
            do
            {
                x = _random.Next(1, Width - 1);
                y = _random.Next(1, Height - 1);
            } while (map[y, x] != EmptyMap);
            map[y, x] = ExpPoint;
        }

        private void PrintMap(char[,] map, int progressScore)
        {
            Console.Clear();
            Console.WriteLine($"\n  Score: {progressScore}\n " +
                $"Use ← ↑ → ↓  to move, [Esc] to quit \n -------------------------- \n");

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        private char[,] GenerationMap()
        {
            char[,] map = new char[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (i == 0 || i == Height - 1 || j == 0 || j == Width - 1)
                    {
                        map[i, j] = BorderMap;
                    }
                    else
                    {
                        map[i, j] = EmptyMap;
                    }
                }
            }
            return map;
        }

    }
}   