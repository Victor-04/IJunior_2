using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace main_1
{
    public class Task41 : ITask
    {
        public void Run()
        {
            int number = 0;

            Console.Clear();
            number = ReadIntegerFromConsole();
            Console.Write($"Your number: {number}");
        }

        public int ReadIntegerFromConsole()
        {
            int integerValue = 0;
            bool retry = true;

            while (retry)
            {
                Console.Write("Input number: ");
                if (int.TryParse(Console.ReadLine(), out integerValue))
                    retry = false;

                if (retry)
                    Console.WriteLine("[Parsing error] Please try again\n");
            }

            return integerValue;
        }
    }
}