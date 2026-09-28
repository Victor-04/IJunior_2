using System;
using System.Collections.Generic;

namespace main_1
{
    public class Task5 : ITask
    {
        public void Run()
        {
            // 1: firstName & lastName
            string firstName = "Иванов";
            string lastName = "Петр";
            Console.WriteLine($"firstName: {firstName}, lastName: {lastName}");
            (firstName, lastName) = reverse(firstName, lastName);
            Console.WriteLine($"firstName: {firstName}, lastName: {lastName}");
            Console.WriteLine("----------------------");

            // 2: cofe & tea
            string cupTea = "cofe";
            string cupCofe = "tea";
            Console.WriteLine($"cup_tea: {cupTea}, cup_cofe: {cupCofe}");
            (cupTea, cupCofe) = reverse(cupTea, cupCofe);
            Console.WriteLine($"cup_tea: {cupTea}, cup_cofe: {cupCofe}");
            Console.WriteLine("----------------------");
        }

        private (string, string) reverse(string first, string second)
        {
            return (second, first);
        }
    }
}