using System;

namespace main_1
{
    public class Task36 : ITask
    {
        public void Run()
        {
            const int ArraySize = 30;
            const int MaxValue= 30;
            const int MinValue = 1;

            Random random = new Random();

            Console.WriteLine();
            Console.WriteLine($"Array size: {ArraySize}");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            int[] array = new int[ArraySize];

            for (int i = 0; i < ArraySize; i++)
            {
                array[i] = random.Next(MinValue, MaxValue + 1);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            int iterations = array.Length - 1;

            for (int i = 0; i < iterations; i++)
            {
                for (int j = 0; j < iterations; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

        }
    }
}