using System;

namespace main_1
{
    public class Task35_1 : ITask
    {
        public void Run()
        {
            const int ArraySize = 30;
            const int MaxValue= 9;
            const int MinValue = 1;

            Random random = new Random();
            int row = ArraySize;

            Console.WriteLine();
            Console.WriteLine($"row: {row}");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            int[] array = new int[row];

            for (int i = 0; i < row; i++)
            {
                array[i] = random.Next(MinValue, MaxValue + 1);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            // ---------------------------

            int arrayLength = array.Length;
            int currentCount = 0;
            int currentValue = 0;
            int bestCount = 0;
            int bestValue = 0;

            if (arrayLength != 0)
            {
                currentValue = array[0];
                currentCount++;

                for (int i = 1; i <= arrayLength; i++)
                {

                    if (i == arrayLength)
                    {
                        if (currentCount > bestCount)
                        {
                            bestValue = currentValue;
                            bestCount = currentCount;
                        }
                    }
                    else if (array[i] == array[i - 1])
                    {
                        currentValue = array[i];
                        currentCount++;
                    }
                    else
                    {
                        if (currentCount > bestCount)
                        {
                            bestValue = currentValue;
                            bestCount = currentCount;
                        }
                        currentValue = array[i];
                        currentCount = 1;
                    }
                }
            }

            Console.Write($"\n Число ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(bestValue);
            Console.ResetColor();
            Console.Write(" повторяется ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(bestCount);
            Console.ResetColor();
            Console.WriteLine(" раза подряд");
        }
    }
}