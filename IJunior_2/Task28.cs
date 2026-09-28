using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;

namespace main_1
{
    public class Task28 : ITask
    {
        public void Run()
        {
            string password = "12345";
            string secretLine = "secret line";
            string inputLine = "";
            int numberAttempts = 3;

            for (int attempt = 0; attempt < numberAttempts; attempt++) 
            {
                Console.Write("Введите пароль: ");
                inputLine = Console.ReadLine();

                if (inputLine == password)
                {
                    Console.Write($"secretLine: {secretLine}");
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка, попробуйте снова");
                }
            }
        }
    }
}