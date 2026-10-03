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
            number = ReadInteger();
            Console.Write($"Your number: {number}");
        }

        public int ReadInteger()
        {
            int integerValue = 0;
            bool isRetry = true;

            while (isRetry)
            {
                Console.Write("Input number: ");
                if (int.TryParse(Console.ReadLine(), out integerValue))
                    isRetry = false;

                if (isRetry)
                    Console.WriteLine("[Parsing error] Please try again\n");
            }

            return integerValue;
        }
    }
}