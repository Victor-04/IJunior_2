using System;

namespace main_1
{
    public class Task32 : ITask
    {
        public void Run()
        {
            const int BorderMatrix = 10;
            const int MaxBorderNumber = 9;
            const int MinBorderNumber = 1;

            Random random = new Random();
            int rows = BorderMatrix;
            int columns = BorderMatrix;
            int maxElement = int.MinValue;

            Console.WriteLine();
            Console.WriteLine($"rows: {rows}");
            Console.WriteLine($"columns: {columns}");
            Console.WriteLine("---------------------");

            int[,] matrix = new int[rows, columns];

            for (int i = 0; i < rows; i++) 
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(MinBorderNumber, MaxBorderNumber + 1);
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                    }
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("---------------------");
            Console.WriteLine($"max element: {maxElement}");
            Console.WriteLine("--------------------- ---------------------");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] == maxElement)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(matrix[i, j] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                }

                Console.Write(" |  ");

                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] == maxElement)
                    {
                        matrix[i, j] = 0;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(matrix[i, j] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("--------------------- ---------------------");
        }
    }
}