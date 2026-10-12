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
            const int BarWidth = 10;
            const char FilledGlyph = '#';
            const char EmptyGlyph = ' ';

            int filledSlots = 0;
            string outputLine = "";

            if (maxValue > 0)
            {
                filledSlots = currentValue * BarWidth / maxValue;
            }

            outputLine =  "[" + new string(FilledGlyph, filledSlots) + new string(EmptyGlyph, BarWidth - filledSlots) + "]";
            
            return outputLine;
        }
    }
}