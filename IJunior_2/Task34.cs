using System;
using System.Reflection;

namespace main_1
{
    public class Task34 : ITask
    {
        public void Run()
        {
            const string SumCommand = "sum";
            const string EndCommand = "end";

            string inputLine = "";
            int[] inputNumbers = { };
            int sumNumbers = 0;
            int occupancyCounter = 0;
            int tempNumber = 0;

            while (true) 
            {
                Console.Clear();
                Console.WriteLine("Enter 'sum' to calculate the sum");
                Console.WriteLine("Enter 'end' to exit the program");
                Console.WriteLine($"Sum numbers: {sumNumbers}");
                Console.Write("Input value: ");
                inputLine = Console.ReadLine();
                Console.WriteLine();

                if (inputLine == SumCommand || inputLine == EndCommand)
                    break;
                
                if (inputNumbers.Length == occupancyCounter)
                {
                    int[] arrayTemp = new int[occupancyCounter + 1];

                    for (int i = 0; i < inputNumbers.Length; i++)
                    {
                        arrayTemp[i] = inputNumbers[i];
                    }

                    tempNumber = Convert.ToInt32(inputLine);
                    arrayTemp[inputNumbers.Length] = tempNumber;
                    sumNumbers += tempNumber;
                    inputNumbers = arrayTemp;
                    occupancyCounter++;
                }
            }

            Console.Clear();
            Console.WriteLine($"Sum numbers: {sumNumbers}");
        }
    }
}