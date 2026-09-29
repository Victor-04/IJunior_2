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
            number = inputerNumericValue();
            Console.Write($"Your number: {number}");
        }

        public int inputerNumericValue()
        {
            int internalNumber = 0;
            bool retry = true;

            while (retry)
            {
                Console.Write("Input number: ");
                if (int.TryParse(Console.ReadLine(), out internalNumber))
                    retry = false;

                if (retry)
                    Console.WriteLine("[Parsing error] Please try again\n");
            }

            return internalNumber;
        }
    }
}