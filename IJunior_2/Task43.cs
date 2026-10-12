using System;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace main_1
{
    public class Task43 : ITask
    {
        public void Run()
        {
            var rng = new Random(42);

            char[] chars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' };
            char[] charsShuffle = Shuffled(chars, rng);
            PrintArray(chars);
            PrintArray(charsShuffle);
            
            Console.WriteLine();

            int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            int[] intsShuffle = Shuffled(ints, rng);
            PrintArray(ints);
            PrintArray(intsShuffle);
        }

        private static T[] Shuffled<T>(T[] array, Random rng)
        {
            T[] copy = array.ToArray();

            for (int i = copy.Length - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (copy[i], copy[j]) = (copy[j], copy[i]);
            }

            return copy;
        }

        private void PrintArray<T>(T[] values)
        {
            Console.WriteLine($"[ {string.Join(", ", values)} ]");
        }
    }
}