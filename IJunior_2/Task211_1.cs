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
    public class Task211_1 : ITask
    {
        public void Run()
        {
            const int MaxHealthHero = 100; 
            const int MaxMagicEnergyHero = 100;
            const int MaxHealthEnemy = 200;
            const int DownBorderDamageEnemy = 10;
            const int UpBorderDamageEnemy = 45;  
            const int DownBorderDamageHero = 15; 
            const int UpBorderDamageHero = 20; 
            const int DamageFireball = 50;
            const int CostMagic = 25;
            const int CountFractionBar = 20; 

            const string Command1 = "Attack";
            const string Command2 = "Fireball";
            const string Command3 = "Сharge";
            const string Command4 = "Healing";
            const string Command5 = "Сomplete"; // завершить ход

            int healthBarHero = MaxHealthHero;
            int magicEnergyBarHero = MaxMagicEnergyHero;
            int healthBarEnemy = MaxHealthEnemy;
            int healthBottleCount = 1;
            int roundGame = 1;

            int countAttackInOneMove = 1;
            int countExplosionInOneMove = 1;
            bool fireballReady = false;

            string ordersPlayer = "";

            bool command1Status = false;
            bool command2Status = false;
            bool command3Status = false;
            bool command4Status = false;
            bool command5Status = true;

            var random = new Random();

            while (healthBarHero > 0 && healthBarEnemy > 0)
            {
                command5Status = true;

                countAttackInOneMove = 1;
                countExplosionInOneMove = 1;
                fireballReady = false;

                while (command5Status) 
                {
                    if (countAttackInOneMove > 0 && fireballReady == false)
                    {
                        command1Status = true;
                    }
                    else
                    {
                        command1Status = false;
                    }

                    if (magicEnergyBarHero >= CostMagic && fireballReady == false && countExplosionInOneMove > 0)
                    {
                        command3Status = true;
                    }
                    else
                    {
                        command3Status = false;
                    }

                    if (command3Status == false && fireballReady == true)
                    {
                        command2Status = true;
                    }
                    else 
                    {
                        command2Status = false;
                    }

                    if (healthBottleCount > 0 && fireballReady == false)
                    {
                        command4Status = true;
                    }
                    else
                    {
                        command4Status = false;
                    }

                    Console.Clear();
                    // проверка доступности команд
                    Console.WriteLine("====-- Command list --====");
                    Console.WriteLine($"====-- press (1) - {Command1}, status: {command1Status} --====");
                    Console.WriteLine($"====-- press (2) - {Command2}, status: {command2Status} --====");
                    Console.WriteLine($"====-- press (3) - {Command3}, status: {command3Status} --====");
                    Console.WriteLine($"====-- press (4) - {Command4}, status: {command4Status} --====");
                    Console.WriteLine($"====-- press (5) - {Command5}, status: {command5Status} --====");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine();

                    Console.WriteLine($"Enemy Health: " + OutBar(healthBarEnemy, MaxHealthEnemy, CountFractionBar));
                    Console.WriteLine("- - - - - - - - - - - - - - - -");
                    Console.WriteLine($"Hero Health: " + OutBar(healthBarHero, MaxHealthHero, CountFractionBar));
                    Console.WriteLine($"Hero MagicEnergy: " + OutBar(magicEnergyBarHero, MaxMagicEnergyHero, CountFractionBar));
                    Console.WriteLine($"Count healthBottle: {healthBottleCount}");
                    Console.WriteLine($"Count Attack: {countAttackInOneMove}");
                    Console.WriteLine($"Count Explosion: {countExplosionInOneMove}");

                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"Round: {roundGame}");
                    Console.Write("Your turn: ");
                    ordersPlayer = Console.ReadLine();

                    switch (ordersPlayer)
                    {
                        case "1":
                            if (command1Status)
                            {
                                healthBarEnemy -= random.Next(DownBorderDamageHero, UpBorderDamageHero + 1);
                                countAttackInOneMove-- ;
                                healthBarEnemy = NormalizationNumber(healthBarEnemy);
                            }
                            break;

                        case "2":
                            if (command2Status)
                            {
                                healthBarEnemy -= DamageFireball;
                                command2Status = false;
                                fireballReady = false;
                                healthBarEnemy = NormalizationNumber(healthBarEnemy);
                            }
                            break;

                        case "3":
                            if (command3Status)
                            {
                                magicEnergyBarHero -= CostMagic;
                                countExplosionInOneMove--;
                                fireballReady = true;
                                command2Status = true;
                            }
                            break;

                        case "4":
                            if (command4Status)
                            {
                                healthBottleCount -= 1;
                                healthBarHero = MaxHealthHero;
                                magicEnergyBarHero = MaxMagicEnergyHero;
                                command4Status = false;
                            }
                            break;

                        case "5":
                            command5Status = false;
                            break;

                        default:
                            command5Status = false;
                            break;
                            // пропуск хода
                    }
                }

                if (healthBarEnemy > 0)
                {
                    healthBarHero -= random.Next(DownBorderDamageEnemy, UpBorderDamageEnemy + 1);
                    healthBarHero = NormalizationNumber(healthBarHero);
                }

                roundGame++;
            }

            Console.Clear();
            Console.WriteLine($"Round: {roundGame - 1}");
            Console.WriteLine($"Enemy Health: " + OutBar(healthBarEnemy, MaxHealthEnemy, CountFractionBar));
            Console.WriteLine("- - - - - - - - - - - - - - - -");
            Console.WriteLine($"Hero Health: " + OutBar(healthBarHero, MaxHealthHero, CountFractionBar));
            Console.WriteLine($"Hero MagicEnergy: " + OutBar(magicEnergyBarHero, MaxMagicEnergyHero, CountFractionBar));

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

            return;
        }

        private string OutBar(int nowStatus, int maxStatus, int sizeFraction)
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

        private int NormalizationNumber(int value)
        {
            if (value < 0)
            {
                return 0;
            }
            return value;
        }
    }
}