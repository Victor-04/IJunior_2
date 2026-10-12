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
            var healthParam = (current: 80, max: 100 );
            var manaParam = (current: 55, max: 135 );

            Console.Clear();
            Console.WriteLine("Your hero params:");
            Console.WriteLine($"Health: {BuildInteractiveBar(healthParam.current, healthParam.max)}");
            Console.WriteLine($"Mana:  {BuildInteractiveBar(manaParam.current, manaParam.max)}");
        }

        public string BuildInteractiveBar(int currentValue, int maxValue)
        {
            int filledSlots = 0;
            string outputLine = "";

            if (currentValue > 0)
            {
                filledSlots = Math.Max(1, (int)(((float)currentValue / (float)maxValue) * BarWidth));
            }
            outputLine += "[";

            for (int i = 0; i < BarWidth; i++)
            {
                if (i < filledSlots)
                {
                    outputLine += FilledGlyph;
                }
                else
                {
                    outputLine += EmptyGlyph;
                }
            }
            outputLine += "]";
            
            return outputLine;
        }
    }
}