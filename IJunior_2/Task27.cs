using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;

namespace main_1
{
    public class Task27 : ITask
    {

        public void Run()
        {
            char symbol = '-';
            int lengthLine = 0;
            string inputLine = "";
            string borderLine = "";

            Console.Write("Ввидите символ: ");
            inputLine = Console.ReadLine();

            if (inputLine.Length > 1)
            {
                Console.Write("Вы ввели больше одного символа!\nПовторите попытку и введите один символ!\n");
                return;
            }

            symbol = inputLine[0];
            Console.Write("Ввидите Имя: ");
            inputLine = Console.ReadLine();

            inputLine = symbol + inputLine + symbol;
            lengthLine = inputLine.Length;

            for (int i = 0; i < lengthLine; i++)
            {
                borderLine += symbol;
            }

            Console.WriteLine();
            Console.WriteLine(borderLine);
            Console.WriteLine(inputLine);
            Console.WriteLine(borderLine);
        }
    }
}