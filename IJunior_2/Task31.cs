using System;

namespace main_1
{
    public class Task31 : ITask
    {
        public void Run()
        {
            const int MaxBorderMatrix = 6;
            const int MinBorderMatrix = 5;
            const int MaxBorderNumber = 9;
            const int MinBorderNumber = 1;
            const int IndexSumRow = 1;          // вторая строка
            const int IndexMultiplyColumn = 0;   // первый столбец 

            Random random = new Random();
            int rows = random.Next(MinBorderMatrix, MaxBorderMatrix + 1);
            int columns = random.Next(MinBorderMatrix, MaxBorderMatrix + 1);
            int sumRow = 0;         
            int multiplyColumn = 1;  

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
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("---------------------");

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                sumRow += matrix[IndexSumRow, j];
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                multiplyColumn *= matrix[i, IndexMultiplyColumn];
            }

            Console.WriteLine($"sum {IndexSumRow} Row: {sumRow}");
            Console.WriteLine($"multiply {IndexMultiplyColumn} Column: {multiplyColumn}");
        }
    }
}