using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Input;

namespace main_1
{
    public class Task26_6 : ITask
    {
        // тут логичнее использовать словарь/карту

        const decimal DollarRateExchange = 78.02m;
        const decimal YuanRateExchange = 11.52m;
        const decimal RubleRateExchange = 1.00m;
        
        const string DollarLabel = "USD";
        const string YuanLabel = "CNY";
        const string RubleLabel = "RUB";

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

        decimal DollarBalance = 0;
        decimal YuanBalance = 0;
        decimal RubleBalance = 0;

        public void Run()
        {
            string comand = "";

            // тут тоже можно придумать что-то интереснее цикла с логическим девером
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
                        FuncHelp(); 
                        break;

                    case CommandRates:
                        FuncRates();
                        break;

                    case CommandBalance:
                        FuncBalance();
                        break;

                    case CommandTopUp:
                        FuncTopUp();
                        break;

                    case CommandConvert:
                        FuncConvert();
                        break;

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

        // ----------------------------------------------------------------- //

        private void FuncHelp()
        {
            Console.WriteLine($"  {CommandHelp}     - Show this help message");
            Console.WriteLine($"  {CommandRates}    - Show rates currency");
            Console.WriteLine($"  {CommandBalance}  - Show balance message");
            Console.WriteLine($"  {CommandTopUp}    - TopUp RUB balance (+100 RUB)");
            Console.WriteLine($"  {CommandClear}    - Clear the console screen");
            Console.WriteLine($"  {CommandExit}     - Exit the program");
            Console.WriteLine("\n");
            Console.WriteLine($"  {CommandConvert}  - Show convert metods");
            ShowConvertMetods();
        }

        private void FuncRates()
        {
            Console.WriteLine($"  {DollarLabel}: {DollarRateExchange}");
            Console.WriteLine($"  {YuanLabel}: {YuanRateExchange}");
            Console.WriteLine($"  {RubleLabel}: {RubleRateExchange}");
        }

        private void ShowConvertMetods()
        {
            Console.WriteLine($"  {CommandUsdToCny} - Convert USD To CNY (one sale or one bay)");
            Console.WriteLine($"  {CommandUsdToRub} - Convert USD To RUB (one sale or one bay)");
            Console.WriteLine($"  {CommandCnyToUsd} - Convert CNY To USD (one sale or one bay)");
            Console.WriteLine($"  {CommandCnyToRub} - Convert CNY To RUB (one sale or one bay)");
            Console.WriteLine($"  {CommandRubToCny} - Convert RUB To CNY (one sale or one bay)");
            Console.WriteLine($"  {CommandRubToUsd} - Convert RUB To CNY (one sale or one bay)");
        }

        private void FuncBalance()
        {
            Console.WriteLine("=== Balance ===");
            Console.WriteLine($"{DollarLabel}: {DollarBalance}");
            Console.WriteLine($"{YuanLabel}: {YuanBalance}");
            Console.WriteLine($"{RubleLabel}: {RubleBalance}");
        }

        private void FuncTopUp()
        {
            Console.WriteLine(" +100 rub");
            RubleBalance += 100;
        }


        private void FuncConvert()
        {
            ShowConvertMetods();
            string convertComand = "";
            Console.Write("Your Convert Command: $ ");
            convertComand = Console.ReadLine();

            switch (convertComand)
            {
                case CommandUsdToCny:
                    ConvertCurrency(DollarLabel, YuanLabel);
                    break;

                case CommandUsdToRub:
                    ConvertCurrency(DollarLabel, RubleLabel);
                    break;

                case CommandCnyToUsd:
                    ConvertCurrency(YuanLabel, DollarLabel);
                    break;

                case CommandCnyToRub:
                    ConvertCurrency(YuanLabel, RubleLabel);
                    break;

                case CommandRubToCny:
                    ConvertCurrency(RubleLabel, YuanLabel);
                    break;

                case CommandRubToUsd:
                    ConvertCurrency(RubleLabel, DollarLabel);
                    break;

                case CommandExit:
                    break;

                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }

        Dictionary<string, decimal> ratesCurrency = new Dictionary<string, decimal>()
        {
            { DollarLabel, DollarRateExchange },
            { YuanLabel, YuanRateExchange },
            { RubleLabel, RubleRateExchange }
        };

        Dictionary<string, decimal> balanceCurrency = new Dictionary<string, decimal>()
        {
            { DollarLabel, 0 },
            { YuanLabel, 0 },
            { RubleLabel, 0 }
        };


        private void ConvertCurrency(string inCurrency, string outCurrency)
        {
            balanceCurrency[DollarLabel] = DollarBalance;
            balanceCurrency[YuanLabel] = YuanBalance;
            balanceCurrency[RubleLabel] = RubleBalance;

            Console.WriteLine($"{inCurrency}: {balanceCurrency[inCurrency]}\n{outCurrency}: {balanceCurrency[outCurrency]}");

            if (balanceCurrency[inCurrency] < 1)
            {
                Console.WriteLine("Insufficient funds to purchase");
                return;
            }

            //double rateConvert = 0;

            if (ratesCurrency[inCurrency] > ratesCurrency[outCurrency])
            {
                decimal outAmaunt = Convert.ToDecimal(Convert.ToDouble(ratesCurrency[inCurrency]) / Convert.ToDouble(ratesCurrency[outCurrency]));

                balanceCurrency[inCurrency] -= 1;
                balanceCurrency[outCurrency] += Math.Round(outAmaunt, 2);
            }
            else
            {
                if (balanceCurrency[inCurrency] < ratesCurrency[outCurrency])
                {
                    Console.WriteLine("Insufficient funds to purchase");
                    return;
                }
                balanceCurrency[outCurrency] += 1;
                balanceCurrency[inCurrency] -= ratesCurrency[outCurrency];
            }

            Console.WriteLine("TopUp success");
            Console.WriteLine($"{inCurrency}: {balanceCurrency[inCurrency]}\n{outCurrency}: {balanceCurrency[outCurrency]}");

            DollarBalance = balanceCurrency[DollarLabel];
            YuanBalance = balanceCurrency[YuanLabel];
            RubleBalance = balanceCurrency[RubleLabel];
        }
    }
}