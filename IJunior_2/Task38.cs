using System;

namespace main_1
{
    public class Task38 : ITask
    {
        public void Run()
        {
            Console.WriteLine();

            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.Write("\nВведите смещение: ");

            int shifts = Convert.ToInt32(Console.ReadLine());
            int arreySize = array.Length;

            if (arreySize > 0)
            {
                if (shifts >= arreySize)
                {
                    shifts = shifts % arreySize;
                }
                for (int s = 1; s <= shifts; s++)
                {
                    int lastElement = array[0];

                    for (int i = 0; i < arreySize - 1; i++)
                    {
                        array[i] = array[i + 1];
                    }
                    array[arreySize - 1] = lastElement;
                }
            }    

            Console.WriteLine();

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}