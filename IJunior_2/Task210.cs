using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;

namespace main_1
{
    public class Task210 : ITask
    {
        const int LowerBorder = 0;
        const int UpperBorder = 999999;
        const int BaseUnit = 2;

        public void Run()
        {
            int hiddenNumber = 0;
            int degreeNumber = 1;

            var r = new Random();
            hiddenNumber = r.Next(LowerBorder, UpperBorder);
            Console.WriteLine($"Число: {hiddenNumber}");

            for (int i = BaseUnit; i <= hiddenNumber; i *= BaseUnit)
            {
                degreeNumber++;
            }

            Console.WriteLine($"Степень {BaseUnit}^{degreeNumber}");
            Console.WriteLine("Число возведенное в степень (проверка): " + Math.Pow(BaseUnit, degreeNumber));
        }
    }
}