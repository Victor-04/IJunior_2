using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace main_1
{
    public class Task42_1 : ITask
    {
        public void Run()
        {
            int[] healthParam = { 80, 100 };
            int[] manaParam = { 55, 135 };

            Console.Clear();
            Console.WriteLine("Your hero params:");
            Console.WriteLine($"Health: {BuildInteractiveBar(healthParam[0], healthParam[1])}");
            Console.WriteLine($"Mana:  {BuildInteractiveBar(manaParam[0], manaParam[1])}");
        }

        private string BuildInteractiveBar(int currentValue, int maxValue)
        {
            const int barWidth = 10;
            const char filledGlyph = '#';
            const char emptyGlyph = ' ';
            int filledSlots = 0;

            if (maxValue > 0)
            {
                filledSlots = currentValue * barWidth / maxValue;
            }

            string outputLine =  "[" + new string(filledGlyph, filledSlots) + new string(emptyGlyph, barWidth - filledSlots) + "]";

            return outputLine;
        }
    }
}