using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace main_1
{
    public class Task42 : ITask
    {
        private const int BarWidth = 10;
        private const char FilledGlyph = '#';
        private const char EmptyGlyph = ' ';

        public void Run()
        {
            var healthParams = (current: 87, max: 253 );
            var manaParams = (current: 79, max: 135 );

            Console.Clear();
            Console.WriteLine("Your hero params:");
            Console.Write("Health: ");
            OutputInteractiveBar(healthParams.current, healthParams.max);
            Console.Write("Mana:  ");
            OutputInteractiveBar(manaParams.current, manaParams.max);
        }

        public void OutputInteractiveBar(int currentValue, int maxValue)
        {
            int filledSlots = 0;

            if (currentValue > 0)
            {
                filledSlots = Math.Max(1, (int)(((float)currentValue / (float)maxValue) * BarWidth));
            }
            Console.Write("[");

            for (int i = 1; i <= BarWidth; i++)
            {
                if (i <= filledSlots)
                {
                    Console.Write(FilledGlyph);
                }
                else 
                {
                    Console.Write(EmptyGlyph);
                }
            }
            Console.Write("]\n");

            return;
        }
    }
}