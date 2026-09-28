using System;

namespace main_1
{
    public class Task41 : ITask
    {
        public void Run()
        {
            int number = 0;
            bool retry = true;

            while (retry)
            {
                Console.Clear();
                Console.Write("Input number: ");
                if (int.TryParse(Console.ReadLine(), out number))
                    retry = false;
            }

            Console.Clear();
            Console.Write($"Your number: {number}");
        }
    }
}