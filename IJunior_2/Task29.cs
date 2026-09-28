using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Input;

namespace main_1
{
    public class Task29 : ITask
    {
        public void Run()
        {
            const int LowerBorder = 50;
            const int UpperBorder = 150;
            const int lowerGenerate = 10;
            const int upperGenerate = 25;

            int targetValue = 0;
            int numberOccurrences = 0;

            var random = new Random();
            targetValue = random.Next(lowerGenerate, upperGenerate + 1);

            Console.WriteLine($"Число: {targetValue}");

            for (int index = targetValue; index < UpperBorder; index += targetValue)
            {
                if (index > LowerBorder)
                {
                    numberOccurrences ++;
                    Console.WriteLine($"Вхождение: {index}");
                }
            }

            Console.WriteLine($"Кол-во кратных {targetValue}: {numberOccurrences}");
        }
    }
}