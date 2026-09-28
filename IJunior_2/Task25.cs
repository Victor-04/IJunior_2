using System;
using System.Collections.Generic;
using System.Reflection;

namespace main_1
{
    public class Task25 : ITask
    {
        const string CommandHelpValue = "/help";
        const string CommandSysInfoValue = "/info";
        const string CommandRandomNumberValue = "/random";
        const string CommandClearValue = "/clean";
        const string CommandExitValue = "/exit";

        const int MaxRandomValue = 9999999;

        public void Run()
        {
            string comand = "";

            Console.Clear();
            Console.WriteLine($"Enter '{CommandHelpValue}' to get help");

            while (comand != CommandExitValue)
            {
                Console.Write("Your Command: "); 
                comand = Console.ReadLine();
                Console.WriteLine();

                switch (comand)
                {
                    case CommandHelpValue:
                        CommandHelp(); 
                        break;

                    case CommandSysInfoValue:
                        CommandSysInfo();
                        break;

                    case CommandRandomNumberValue:
                        CommandRandomNumber();
                        break;

                    case CommandClearValue:
                        Console.Clear();
                        break;

                    case CommandExitValue:
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }

                if (comand != CommandClearValue)
                {
                    Console.WriteLine();
                }
            }
        }

        // ----------------------------------------------------------------- //

        private void CommandHelp()
        {
            Console.WriteLine($"  {CommandHelpValue}     - Show this help message");
            Console.WriteLine($"  {CommandSysInfoValue}     - Display system information");
            Console.WriteLine($"  {CommandRandomNumberValue}   - Generate a random number");
            Console.WriteLine($"  {CommandClearValue}    - Clear the console screen");
            Console.WriteLine($"  {CommandExitValue}     - Exit the program");
        }

        private void CommandSysInfo()
        {
            Console.WriteLine("=== SYSTEM INFORMATION ===\n");
            Console.WriteLine($"ОС: {Environment.OSVersion}");
            Console.WriteLine($"CPU: Intel Core i5-12400K @ 3.60GHz");
            Console.WriteLine($"RAM (Total): 32.00 GB");
            Console.WriteLine($"RAM (Free): 24.50 GB");

            Console.WriteLine("\n--- GRAPHICS INFORMATION ---\n");
            Console.WriteLine($"GPU: NVIDIA GeForce RTX 4080");
            Console.WriteLine($"Video Memory: 16.00 GB");
        }

        private void CommandRandomNumber()
        {
            var random = new Random();
            int randomValue = random.Next(MaxRandomValue);
            Console.WriteLine($"{randomValue}");
        }
    }
}