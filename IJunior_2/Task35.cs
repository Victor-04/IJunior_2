namespace main_1
{
    public class Task35 : ITask
    {
        public void Run()
        {
            const int ArraySize = 30;
            const int MaxBorderNumber = 9;
            const int MinBorderNumber = 1;

            Random random = new Random();
            int row = ArraySize;

            Console.WriteLine();
            Console.WriteLine($"row: {row}");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            int[] array = new int[row];

            for (int i = 0; i < row; i++)
            {
                array[i] = random.Next(MinBorderNumber, MaxBorderNumber + 1);
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");

            // ---------------------------

            int arrayLength = array.Length;
            int indexElementsLineLength = 0;


            int[] indexElements = { };
            int numberRepetitions = 0;
            int numberTarget = 0;

            int[] indexElementsMax = { };
            int numberRepetitionsMax = 0;
            int numberTargetMax = 0;

            indexElements = new int[] { 0 };
            numberTarget = array[0];
            numberRepetitions++;

            for (int i = 1; i < arrayLength; i++)
            {
                if (array[i] == array[i - 1])
                {
                    indexElements = expandArray(indexElements, i);
                    numberTarget = array[i];
                    numberRepetitions++;
                }
                else 
                {
                    if (numberRepetitions > numberRepetitionsMax)
                    {
                        indexElementsMax = indexElements;
                        numberTargetMax = numberTarget;
                        numberRepetitionsMax = numberRepetitions;
                    }
                        indexElements = new int[] { i };
                        numberTarget = array[i];
                        numberRepetitions = 1;
                }
            }

            indexElementsLineLength = indexElementsMax.Length;

            for (int i = 0; i < arrayLength; i++)
            {
                if (i >= indexElementsMax[0] && i <= indexElementsMax[indexElementsLineLength - 1])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(array[i] + " ");
                    Console.ResetColor();
                }
                else 
                {
                    Console.Write(array[i] + " ");
                }
            }

            Console.Write($"\n\n Число ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(numberTargetMax);
            Console.ResetColor();
            Console.Write(" повторяется ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(numberRepetitionsMax);
            Console.ResetColor();
            Console.WriteLine(" раза подряд");
        }

        public int[] expandArray(int[] inputArary, int number)
        {
            int lengthArray = inputArary.Length;
            int[] tempArray = new int[lengthArray + 1]; ;

            for (int i = 0; i < lengthArray; i++)
            {
                tempArray[i] = inputArary[i];
            }

            tempArray[lengthArray] = number;

            return tempArray;
        }
    }
}