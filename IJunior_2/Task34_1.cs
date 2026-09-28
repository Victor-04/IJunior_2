using System;
using System.Reflection;

namespace main_1
{
    public class Task34_1 : ITask
    {
        public void Run()
        {
            const string SumCommand = "sum";
            const string EndCommand = "end";

            string inputLine = "";
            int[] inputNumbers = { };
            int sumNumbers = 0;
 
            while (inputLine != EndCommand)
            {
                Console.Clear();
                Console.WriteLine($"Enter '{SumCommand}' to calculate the sum");
                Console.WriteLine($"Enter '{EndCommand}' to exit the program");
                Console.WriteLine("< ----------------------------------- >");
                Console.Write("[ ");
                foreach (var item in inputNumbers)
                {
                    Console.Write($"{item} ; ");
                }
                Console.Write(" ]\n");
                Console.WriteLine($"sumNumbers: {sumNumbers}\n");

                Console.Write("Введите значение: ");
                inputLine = Console.ReadLine();
                Console.WriteLine();

                switch (inputLine)
                {
                    case SumCommand:
                        foreach (var item in inputNumbers)
                        {
                            sumNumbers += item;
                            inputNumbers = new int[] { };
                        }
                        break;

                    case EndCommand:
                        break;

                    default:
                        int lengthArray = inputNumbers.Length;
                        int[] arrayTemp = new int[lengthArray + 1];

                        for (int i = 0; i < lengthArray; i++)
                        {
                            arrayTemp[i] = inputNumbers[i];
                        }

                        if (lengthArray == 0)
                            sumNumbers = 0;

                        arrayTemp[lengthArray] = Convert.ToInt32(inputLine);
                        inputNumbers = arrayTemp;
                        break;
                }
            }

        }
    }
}