using System;

namespace main_1
{
    public class Task37 : ITask
    {
        public void Run()
        {
            string row = "Duis aute irure " +
                "dolor in reprehenderit in voluptate, " +
                "nam libero tempore, cum soluta nobis est " +
                "eligendi optio, cumque nihil impedit, quo minus " +
                "id, quod maxime placeat, facere possimus, omnis " +
                "voluptas assumenda est, omnis dolor repellendus.";

            Console.WriteLine($"{row}\n");

            string[] words = row.Split();
            Console.WriteLine($"words.Length: {words.Length}");

            for (int i = 0; i < words.Length; i++)
            {
                Console.WriteLine($"[{i}]: {words[i]}");
            }
        }
    }
}