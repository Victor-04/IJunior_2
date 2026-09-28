using System;

namespace main_1
{
    public class Task4 : ITask
    {
        public void Run()
        {
            int countImage = 52;
            int countOneRow = 3;
            int filled = countImage / countOneRow;
            int remains = countImage % countOneRow;
            Console.WriteLine($"{countImage} картинки по {countOneRow} в ряд");
            Console.WriteLine("----------------------");
            Console.WriteLine($"Заполнено рядов: {filled}");
            Console.WriteLine($"Остаток: {remains}");
        }
    }
}