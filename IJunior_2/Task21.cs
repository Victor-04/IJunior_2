using System;
using System.Collections.Generic;

namespace main_1
{
    public class Task21 : ITask
    {
        public void Run()
        {
            string textRetry = "";
            uint countRetry = 0;

            Console.WriteLine("Что вы хотите повторить?");
            textRetry = Console.ReadLine();

            Console.WriteLine("Сколько раз?");
            countRetry = Convert.ToUInt32(Console.ReadLine());

            for (int i = 0; i < countRetry; i++)
            {
                Console.WriteLine(textRetry);
            }

        }
    }
}