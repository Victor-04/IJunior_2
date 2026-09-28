using System;
using System.Collections.Generic;
using System.Reflection;

namespace main_1
{
    public class Task24 : ITask
    {
        public void Run()
        {
            var random = new Random();

            int targetValue = 0;
            //int maxBorder = 100;
            int firstСondition = 3; // эффективнее такие данные держать в массиве (но мы их еще не проходили :) )
            int secondCondition = 5;
            int totalSum = 0;

            string checkLine = "";

            targetValue = random.Next(100);
            Console.WriteLine($"Загаданное число: {targetValue}");

            for (int i = 0; i <= targetValue; i++)
            {
                if (i % firstСondition == 0 || i % secondCondition == 0)
                {
                    checkLine += $"{i} ";
                    totalSum += i;
                }
            }

            Console.WriteLine($"Сумма значений: {totalSum}");
            Console.WriteLine($"Строка для проверки: {checkLine}");
        }
    }
}