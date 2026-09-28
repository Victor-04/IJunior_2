using System;
using System.Collections.Generic;

namespace main_1
{
    public class Task22 : ITask
    {
        public void Run()
        {
            int totalSum = 0;
            int interSum = 0;
            int firstItem = 0;
            int secondItem = 0;
            uint countIteration = 0;
            string inputText = "";

            Console.WriteLine("Калькулятор сложения двух чисел. (для выхода введите 'exit')");
            while (true)
            {
                Console.WriteLine("Введите первое слогаемое?");
                inputText = Console.ReadLine();
                if (inputText == "exit")
                {
                    break;
                }
                firstItem = Convert.ToInt32(inputText);

                Console.WriteLine("Введите второе слогаемое?");
                inputText = Console.ReadLine();
                if (inputText == "exit")
                {
                    break;
                }
                secondItem = Convert.ToInt32(inputText);

                interSum = firstItem + secondItem;
                Console.WriteLine($"Результат: {interSum}");

                totalSum += interSum;
                countIteration++;
            }

            Console.WriteLine($"Выход из цикла. Count loop: {countIteration}. Total sum by operations: {totalSum}");

        }
    }
}