using System;

namespace main_1
{
    public class Task33 : ITask
    {
        public void Run()
        {
            const int ArraySize = 30;
            const int MaxBorderNumber = 99;
            const int MinBorderNumber = 10;

            Random random = new Random();
            int row = ArraySize;

            Console.WriteLine();
            Console.WriteLine($"rows: {row}");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            int[] array = new int[row];

            for (int i = 0; i < row; i++)
            {
                array[i] = random.Next(MinBorderNumber, MaxBorderNumber + 1);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            int arrayLength = array.Length;
            string localMaxElements = "";
            int firstElement = 0;

            
            if (array[firstElement] > array[firstElement + 1])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(array[firstElement] + " ");
                Console.ResetColor();
                localMaxElements += $"{array[firstElement]} ";
            }
            else
            {
                Console.Write(array[firstElement] + " ");
            }

            for (int i = 1; i < arrayLength - 1; i++)
            {
                
                if (array[i - 1] < array[i] && array[i] > array[i + 1])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(array[i] + " ");
                    Console.ResetColor();
                    localMaxElements += $"{array[i]} ";
                }
                else
                {
                    Console.Write(array[i] + " ");
                }
            }

            if (array[arrayLength - 2] < array[arrayLength - 1])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(array[arrayLength - 1] + " ");
                Console.ResetColor();
                localMaxElements += $"{array[arrayLength - 1]} ";
            }
            else
            {
                Console.Write(array[arrayLength - 1] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine(localMaxElements);
        }
    }
}