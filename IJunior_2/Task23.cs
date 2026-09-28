using System;
using System.Collections.Generic;

namespace main_1
{
    public class Task23 : ITask
    {
        public void Run()
        {

            int initValue = 5;
            int finalValue = 103;
            int stepValue = 7;
            int countIterations = 0;

            countIterations = (finalValue - initValue) / stepValue;

            for (int i = initValue; i <= finalValue; i += stepValue)
            {
                Console.Write($"{i} ");
            }
        }
    }
}