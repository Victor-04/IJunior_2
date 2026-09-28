using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Windows.Input;

namespace main_1
{
    public class Task211_2 : ITask
    {
        public void Run()
        {
            const int MaxHealthHero = 100; 
            const int MaxMagicEnergyHero = 100;
            const int MaxHealthEnemy = 200;
            const int DownBorderDamageEnemy = 10;
            const int UpBorderDamageEnemy = 45;  
            const int DownBorderDamageHero = 20; 
            const int UpBorderDamageHero = 35;
            const int DamageFireball = 50;
            const int CostMagic = 25;
            const int CountFractionBar = 20;

            const string CommandAttack = "1";
            const string CommandFireball = "2";
            const string CommandCharge = "3";
            const string CommandHealing = "4";

            var commandNames = new Dictionary<string, string>
            {
                [CommandAttack] = "Attack",
                [CommandFireball] = "Fireball",
                [CommandCharge] = "Сharge",
                [CommandHealing] = "Healing"
            };

            var commandAvailability  = new Dictionary<string, bool>
            {
                [CommandAttack] = true,
                [CommandFireball] = false,
                [CommandCharge] = false,
                [CommandHealing] = false
            };

            int healthBarHero = MaxHealthHero;
            int magicEnergyBarHero = MaxMagicEnergyHero;
            int healthBarEnemy = MaxHealthEnemy;
            int healthBottleCount = 2;
            int roundGame = 1;

            string inputCommand = "";

            var random = new Random();

            while (healthBarHero > 0 && healthBarEnemy > 0)
            {
                commandAvailability[CommandAttack] = !commandAvailability[CommandFireball];
                commandAvailability[CommandCharge] = magicEnergyBarHero >= CostMagic && !commandAvailability[CommandFireball];
                commandAvailability[CommandHealing] = healthBottleCount > 0 && !commandAvailability[CommandFireball];

                Console.Clear();
                // проверка доступности команд
                Console.WriteLine("====-- Command list --====");
                Console.WriteLine($"====-- press key ({CommandAttack}) - {commandNames[CommandAttack]}, status: {commandAvailability [CommandAttack]} --====");
                Console.WriteLine($"====-- press key ({CommandFireball}) - {commandNames[CommandFireball]}, status: {commandAvailability [CommandFireball]} --====");
                Console.WriteLine($"====-- press key ({CommandCharge}) - {commandNames[CommandCharge]}, status: {commandAvailability [CommandCharge]} --====");
                Console.WriteLine($"====-- press key ({CommandHealing}) - {commandNames[CommandHealing]}, status: {commandAvailability [CommandHealing]} --====");
                Console.WriteLine("------------------------------");
                Console.WriteLine();
                Console.WriteLine($"Enemy Base Damage: {DownBorderDamageEnemy} - {UpBorderDamageEnemy}");
                Console.WriteLine($"Hero Base Damage: {DownBorderDamageHero} - {UpBorderDamageHero}");
                Console.WriteLine($"Hero Fireball Damage: {DamageFireball}");
                Console.WriteLine("------------------------------");
                Console.WriteLine();
                Console.WriteLine($"Enemy Health: " + DisplayPointsBar(healthBarEnemy, MaxHealthEnemy, CountFractionBar));
                Console.WriteLine("- - - - - - - - - - - - - - - -");
                Console.WriteLine($"Hero Health: " + DisplayPointsBar(healthBarHero, MaxHealthHero, CountFractionBar));
                Console.WriteLine($"Hero MagicEnergy: " + DisplayPointsBar(magicEnergyBarHero, MaxMagicEnergyHero, CountFractionBar));
                Console.WriteLine($"Count healthBottle: {healthBottleCount}");

                Console.WriteLine("------------------------------");
                Console.WriteLine($"Round: {roundGame}");
                Console.Write("Your turn: ");
                inputCommand = Console.ReadLine();

                switch (inputCommand)
                {
                    case CommandAttack:
                        if (commandAvailability[CommandAttack])
                        {
                            healthBarEnemy -= random.Next(DownBorderDamageHero, UpBorderDamageHero + 1);
                            healthBarEnemy = NormalizeNumber(healthBarEnemy);
                        }
                        break;

                    case CommandFireball:
                        if (commandAvailability[CommandFireball])
                        {
                            healthBarEnemy -= DamageFireball;
                            commandAvailability [CommandFireball] = false;
                            healthBarEnemy = NormalizeNumber(healthBarEnemy);
                        }
                        break;

                    case CommandCharge:
                        if (commandAvailability[CommandCharge])
                        {
                            magicEnergyBarHero -= CostMagic;
                            commandAvailability[CommandCharge] = false;
                            commandAvailability[CommandFireball] = true;
                        }
                        break;

                    case CommandHealing:
                        if (commandAvailability[CommandHealing])
                        {
                            healthBottleCount -= 1;
                            healthBarHero = MaxHealthHero;
                            magicEnergyBarHero = MaxMagicEnergyHero;
                        }
                        break;

                    default:
                        break;
                }

                if (healthBarEnemy > 0)
                {
                    healthBarHero -= random.Next(DownBorderDamageEnemy, UpBorderDamageEnemy + 1);
                    healthBarHero = NormalizeNumber(healthBarHero);
                }

                roundGame++;
            }

            Console.Clear();
            Console.WriteLine($"Round: {roundGame - 1}");
            Console.WriteLine($"Enemy Health: " + DisplayPointsBar(healthBarEnemy, MaxHealthEnemy, CountFractionBar));
            Console.WriteLine("- - - - - - - - - - - - - - - -");
            Console.WriteLine($"Hero Health: " + DisplayPointsBar(healthBarHero, MaxHealthHero, CountFractionBar));
            Console.WriteLine($"Hero MagicEnergy: " + DisplayPointsBar(magicEnergyBarHero, MaxMagicEnergyHero, CountFractionBar));

            if (healthBarHero > 1)
            {
                Console.WriteLine("====----------------------------------------------====");
                Console.WriteLine("====-- ★ You Win ★ --====");
            }
            else 
            {
                Console.WriteLine("====----------------------------------------------====");
                Console.WriteLine("====-- 🕇 You Lose 🕇 --====");
            }
        }

        private string DisplayPointsBar(int nowStatus, int maxStatus, int sizeFraction)
        {
            string outLine = "{";
            int unitPaint = 0;
            int countUnitsPaint = 0;

            unitPaint = maxStatus / sizeFraction;
            countUnitsPaint = nowStatus / unitPaint;

            for (int i = 0; i < sizeFraction; i++)
            {
                if (i < countUnitsPaint)
                {
                    outLine += "#";
                }
                else
                {
                    outLine += " ";
                }
            }

            outLine += "}" + $" {nowStatus} hp";

            return outLine;
        }

        private int NormalizeNumber(int value)
        {
            if (value < 0)
            {
                return 0;
            }
            return value;
        }
    }
}