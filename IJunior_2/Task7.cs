using System;
using System.Collections.Generic;

namespace main_1
{
    public class Task7 : ITask
    {
        public void Run()
        {
            uint countPeople = 0;
            uint timeMinuteWait = 10;
            uint timeTotalWait = 0;
            uint constTimeSecondMinute = 60;
            uint hours = 0;
            uint minutes = 0;

            Console.WriteLine("Сколько людей в очереди?");
            countPeople = Convert.ToUInt32(Console.ReadLine());

            timeTotalWait = countPeople * timeMinuteWait;
            hours = timeTotalWait / constTimeSecondMinute;
            minutes = timeTotalWait % constTimeSecondMinute;

            Console.WriteLine($"Вы должны отстоять в очереди {hours} " +
                $"часа и {minutes} минут.");

        }
    }
}