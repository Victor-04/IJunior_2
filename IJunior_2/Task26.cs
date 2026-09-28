using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;

namespace main_1
{
    public class Task26 : ITask
    {
        const decimal USDRateExchange = 78.02m;
        const decimal CNYRateExchange = 11.52m;
        const decimal RUBRateExchange = 1.00m;

        const decimal TopUpValue = 100;

        const string USDLabel = "USD";
        const string CNYLabel = "CNY";
        const string RUBLabel = "RUB";

        const string CommandHelp = "/help";
        const string CommandBalance = "/balance";
        const string CommandRates = "/rates";
        const string CommandTopUp = "/topup";
        const string CommandClear = "/clean";
        const string CommandExit = "/exit";

        const string CommandConvert = "/convert";
        const string CommandUsdToCny = "/usd-cny";
        const string CommandUsdToRub = "/usd-rub";
        const string CommandCnyToUsd = "/cny-usd";
        const string CommandCnyToRub = "/cny-rub";
        const string CommandRubToCny = "/rub-cny";
        const string CommandRubToUsd = "/rub-usd";

        decimal USDBalance = 0;
        decimal CNYBalance = 0;
        decimal RUBBalance = 0;

        public void Run()
        {
            string comand = "";

            Console.Clear();
            Console.WriteLine($"Enter '{CommandHelp}' to get help");

            while (comand != CommandExit)
            {
                Console.Write("Your Command: "); 
                comand = Console.ReadLine();
                Console.WriteLine();

                switch (comand)
                {
                    case CommandHelp:
                        {
                            Console.WriteLine($"  {CommandHelp}     - Show this help message");
                            Console.WriteLine($"  {CommandRates}    - Show rates currency");
                            Console.WriteLine($"  {CommandBalance}  - Show balance message");
                            Console.WriteLine($"  {CommandTopUp}    - TopUp RUB balance (+{TopUpValue} RUB)");
                            Console.WriteLine($"  {CommandClear}    - Clear the console screen");
                            Console.WriteLine($"  {CommandExit}     - Exit the program");
                            Console.WriteLine("\n");
                            Console.WriteLine($"  {CommandConvert}  - Show convert metods");
                            Console.WriteLine($"  {CommandUsdToCny} - Convert USD To CNY (one sale or one bay)");
                            Console.WriteLine($"  {CommandUsdToRub} - Convert USD To RUB (one sale or one bay)");
                            Console.WriteLine($"  {CommandCnyToUsd} - Convert CNY To USD (one sale or one bay)");
                            Console.WriteLine($"  {CommandCnyToRub} - Convert CNY To RUB (one sale or one bay)");
                            Console.WriteLine($"  {CommandRubToCny} - Convert RUB To CNY (one sale or one bay)");
                            Console.WriteLine($"  {CommandRubToUsd} - Convert RUB To CNY (one sale or one bay)");
                            break;
                        }

                    case CommandRates:
                        {
                            Console.WriteLine($"  {USDLabel}: {USDRateExchange}");
                            Console.WriteLine($"  {CNYLabel}: {CNYRateExchange}");
                            Console.WriteLine($"  {RUBLabel}: {RUBRateExchange}");
                            break;
                        }

                    case CommandBalance:
                        {
                            Console.WriteLine("=== Balance ===");
                            Console.WriteLine($"{USDLabel}: {USDBalance}");
                            Console.WriteLine($"{CNYLabel}: {CNYBalance}");
                            Console.WriteLine($"{RUBLabel}: {RUBBalance}");
                            break;
                        }

                    case CommandTopUp:
                        {
                            Console.WriteLine($" +{TopUpValue} rub");
                            RUBBalance += TopUpValue;
                            break;
                        }

                    case CommandConvert:
                        {
                            Console.WriteLine($"  {CommandUsdToCny} - Convert USD To CNY (one sale or one bay)");
                            Console.WriteLine($"  {CommandUsdToRub} - Convert USD To RUB (one sale or one bay)");
                            Console.WriteLine($"  {CommandCnyToUsd} - Convert CNY To USD (one sale or one bay)");
                            Console.WriteLine($"  {CommandCnyToRub} - Convert CNY To RUB (one sale or one bay)");
                            Console.WriteLine($"  {CommandRubToCny} - Convert RUB To CNY (one sale or one bay)");
                            Console.WriteLine($"  {CommandRubToUsd} - Convert RUB To CNY (one sale or one bay)");

                            string convertComand = "";
                            Console.Write("Your Convert Command: $ ");
                            convertComand = Console.ReadLine();

                            switch (convertComand)
                            {
                                case CommandUsdToCny:
                                    {
                                        if (USDBalance < 1)
                                        {
                                            Console.WriteLine("Insufficient funds to purchase");
                                            break;
                                        }

                                        decimal outAmaunt = Convert.ToDecimal(Convert.ToDouble(USDRateExchange) / Convert.ToDouble(CNYRateExchange));
                                        USDBalance -= 1;
                                        CNYBalance += Math.Round(outAmaunt, 2);

                                        Console.WriteLine("=== Balance ===");
                                        Console.WriteLine($"{USDLabel}: {USDBalance}");
                                        Console.WriteLine($"{CNYLabel}: {CNYBalance}");
                                        Console.WriteLine($"{RUBLabel}: {RUBBalance}");

                                        break;
                                    }

                                case CommandUsdToRub:
                                    {
                                        if (USDBalance < 1)
                                        {
                                            Console.WriteLine("Insufficient funds to purchase");
                                            break;
                                        }

                                        decimal outAmaunt = Convert.ToDecimal(Convert.ToDouble(USDRateExchange) / Convert.ToDouble(RUBRateExchange));
                                        USDBalance -= 1;
                                        RUBBalance += Math.Round(outAmaunt, 2);

                                        Console.WriteLine("=== Balance ===");
                                        Console.WriteLine($"{USDLabel}: {USDBalance}");
                                        Console.WriteLine($"{CNYLabel}: {CNYBalance}");
                                        Console.WriteLine($"{RUBLabel}: {RUBBalance}");

                                        break;
                                    }

                                // ----------

                                case CommandCnyToUsd:
                                    {
                                        if (CNYBalance < (USDRateExchange / CNYRateExchange))
                                        {
                                            Console.WriteLine("Insufficient funds to purchase");
                                            break;
                                        }

                                        USDBalance += 1;
                                        CNYBalance -= USDRateExchange / CNYRateExchange;

                                        Console.WriteLine("=== Balance ===");
                                        Console.WriteLine($"{USDLabel}: {USDBalance}");
                                        Console.WriteLine($"{CNYLabel}: {CNYBalance}");
                                        Console.WriteLine($"{RUBLabel}: {RUBBalance}");

                                        break;
                                    }

                                case CommandCnyToRub:
                                    {
                                        if (CNYBalance < 1)
                                        {
                                            Console.WriteLine("Insufficient funds to purchase");
                                            break;
                                        }

                                        decimal outAmaunt = Convert.ToDecimal(Convert.ToDouble(CNYRateExchange) / Convert.ToDouble(RUBRateExchange));
                                        CNYBalance -= 1;
                                        RUBBalance += Math.Round(outAmaunt, 2);

                                        Console.WriteLine("=== Balance ===");
                                        Console.WriteLine($"{USDLabel}: {USDBalance}");
                                        Console.WriteLine($"{CNYLabel}: {CNYBalance}");
                                        Console.WriteLine($"{RUBLabel}: {RUBBalance}");

                                        break;
                                    }

                                // ----------

                                case CommandRubToCny:
                                    {
                                        if (RUBBalance < USDRateExchange)
                                        {
                                            Console.WriteLine("Insufficient funds to purchase");
                                            break;
                                        }

                                        CNYBalance += 1;
                                        RUBBalance -= CNYRateExchange;

                                        Console.WriteLine("=== Balance ===");
                                        Console.WriteLine($"{USDLabel}: {USDBalance}");
                                        Console.WriteLine($"{CNYLabel}: {CNYBalance}");
                                        Console.WriteLine($"{RUBLabel}: {RUBBalance}");

                                        break;
                                    }
   
                                case CommandRubToUsd:
                                    {
                                        if (RUBBalance < USDRateExchange)
                                        {
                                            Console.WriteLine("Insufficient funds to purchase");
                                            break;
                                        }

                                        USDBalance += 1;
                                        RUBBalance -= USDRateExchange;

                                        Console.WriteLine("=== Balance ===");
                                        Console.WriteLine($"{USDLabel}: {USDBalance}");
                                        Console.WriteLine($"{CNYLabel}: {CNYBalance}");
                                        Console.WriteLine($"{RUBLabel}: {RUBBalance}");

                                        break;
                                    }

                                // ----------

                                case CommandExit:
                                    break;

                                default:
                                    Console.WriteLine("Unknown command");
                                    break;
                            }
                            break;
                        }

                    case CommandClear:
                        Console.Clear();
                        break;

                    case CommandExit:
                        break;

                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }

                if (comand != CommandClear)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}