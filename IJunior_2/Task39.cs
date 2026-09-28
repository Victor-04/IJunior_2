using System;

namespace main_1
{
    public class Task39 : ITask
    {
        public void Run()
        {
            const char InputGlyph = '(';
            const char OutputGlyph = ')';

            string inputLine = "";
            int counterIn = 0;
            int maxIn = 0;

            Console.Write("\nВведите строку: ");
            inputLine = Console.ReadLine();

            if (inputLine.Length == 0)
                inputLine = "(()(()))"; 

            for (int i = 0; i < inputLine.Length; i++)
            {
                switch (inputLine[i])
                {
                    case InputGlyph:
                        counterIn++;
                        break;

                    case OutputGlyph:
                        counterIn--;
                        break;

                    default:
                        break;
                }

                if (counterIn > maxIn)
                    maxIn = counterIn;

                if (counterIn < 0)
                    break;
            }

            Console.WriteLine();

            if (counterIn == 0)
                Console.WriteLine("Status: OK");
            else
                Console.WriteLine("Status: ERROR");

            Console.WriteLine($"Max deep: {maxIn}");
            Console.WriteLine($"[DEBUG] counterIn: {counterIn}");
        }
    }
}