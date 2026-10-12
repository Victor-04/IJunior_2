using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace main_1
{
    public class Task42_2 : ITask
    {
        public void Run()
        {
            int[] healthParam = { 80, 10 };
            int[] manaParam = { 55, 13 };

            Console.Clear();
            Console.WriteLine("Your hero params:");
            Console.WriteLine($"Health: {BuildInteractiveBar(healthParam[0], healthParam[1])}");
            Console.WriteLine($"Mana:   {BuildInteractiveBar(manaParam[0], manaParam[1])}");
        }

        private string BuildInteractiveBar(int percentFilling, int lengthBar)
        {
            percentFilling = (percentFilling > 100) ? 100 : percentFilling;
            percentFilling = (percentFilling < 0) ? 0 : percentFilling;
            lengthBar = (lengthBar < 0) ? 0 : lengthBar;

            const char FilledGlyph = '#';
            const char EmptyGlyph = '_';

            int filledSlots = lengthBar * percentFilling / 100;
            
            return "[" + new string(FilledGlyph, filledSlots) + new string(EmptyGlyph, lengthBar - filledSlots) + "]";
        }
    }
}