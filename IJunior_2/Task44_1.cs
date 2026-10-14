using System.ComponentModel.Design;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace main_1
{
    public class Task44_1 : ITask
    {
        private const string CommandAdd = "1";
        private const string CommandPrint = "2";
        private const string CommandRemove = "3";
        private const string CommandFind = "4";
        private const string CommandExit = "5";

        public void Run()
        {
            string[] names =
            {
                "Иванов Иван Иванович",
                "Петров Пётр Петрович",
                "Сидорова Анна Ивановна",
            };

            string[] positions =
            {
                "Разработчик",
                "Тестировщик",
                "Менеджер",
            };

            bool isRunning = true;
            Console.Clear();

            while (isRunning)
            {
                PrintMenu();
                Console.Write("Enter command: ");
                string command = (Console.ReadLine() ?? "").Trim();

                switch (command)
                {
                    case CommandAdd:
                        AddDossier(ref names, ref positions);
                        break;
                    case CommandPrint:
                        PrintAllDossiers(names, positions);
                        break;
                    case CommandRemove:
                        RemoveDossier(ref names, ref positions);
                        break;
                    case CommandFind:
                        FindByLastName(names, positions);
                        break;
                    case CommandExit:
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }

            Console.WriteLine("Exiting the program.");
        }

        private void PrintMenu()
        {
            Console.WriteLine("-== Dossier Manager ==-");
            Console.WriteLine($"  {CommandAdd}: Add dossier");
            Console.WriteLine($"  {CommandPrint}: Print all dossiers");
            Console.WriteLine($"  {CommandRemove}: Remove dossier");
            Console.WriteLine($"  {CommandFind}: Find by last name");
            Console.WriteLine($"  {CommandExit}: Exit");
            Console.WriteLine();
        }

        private string[] AddToEnd(string[] array, string value)
        {
            int arrayLength = array.Length;
            string[] result = new string[arrayLength + 1];

            for (int i = 0; i < arrayLength; i++)
            {
                result[i] = array[i];
            }

            result[arrayLength] = value;
            return result;
        }

        private string[] RemoveAt(string[] array, int index)
        {
            int arrayLength = array.Length;
            string[] result = new string[arrayLength - 1];
            int mainIndex = 0;

            for (int i = 0; i < index; i++)
            {
                result[mainIndex] = array[i];
                mainIndex++;
            }

            for (int i = index + 1; i < arrayLength; i++)
            {
                result[mainIndex] = array[i];
                mainIndex++;
            }

            return result;
        }

        private void AddDossier(ref string[] names, ref string[] positions)
        {
            Console.Clear();
            Console.Write("Enter full name (Фамилия Имя Отчество): ");
            string fullName = Console.ReadLine() ?? "";

            if (fullName == "")
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }

            Console.Write("Enter position: ");
            string position = Console.ReadLine() ?? "";

            if (position == "")
            {
                Console.WriteLine("Position cannot be empty.");
                return;
            }

            names = AddToEnd(names, fullName);
            positions = AddToEnd(positions, position);

            Console.WriteLine("Dossier added successfully.");
        }

        private void PrintAllDossiers(string[] names, string[] positions)
        {
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - -");

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {names[i]} - {positions[i]}");
            }

            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - -\n");
        }

        private void RemoveDossier(ref string[] names, ref string[] positions)
        {
            Console.Clear();
            int arrayLength = names.Length;

            if (arrayLength == 0)
            {
                Console.WriteLine("No dossiers to remove.");
                return;
            }

            PrintAllDossiers(names, positions);

            Console.Write("Enter dossier number to remove: ");

            if (int.TryParse(Console.ReadLine(), out int number) == false)
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            if (number < 1 || number > arrayLength)
            {
                Console.WriteLine($"Number must be between 1 and {arrayLength}.");
                return;
            }

            int index = number - 1;

            names = RemoveAt(names, index);
            positions = RemoveAt(positions, index);

            Console.WriteLine("Dossier removed successfully.");
        }

        private void FindByLastName(string[] names, string[] positions)
        {
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - -");

            Console.Write("Enter last name to search: ");
            string query = Console.ReadLine() ?? "";

            int foundCount = 0;

            for (int i = 0; i < names.Length; i++)
            {
                if (GetLastName(names[i]).Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{i + 1} - {names[i]} - {positions[i]}");
                    foundCount++;
                }
            }

            if (foundCount == 0)
            {
                Console.WriteLine($"No dossiers found with last name '{query}'.");
            }
            else
            {
                Console.WriteLine($"Found {foundCount} dossier(s).");
            }

            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - -\n");
        }

        private string GetLastName(string fullName)
        {
            int spaceIndex = fullName.IndexOf(' ');

            if (spaceIndex == -1)
            {
                return fullName;
            }

            return fullName.Substring(0, spaceIndex);
        }
    }
}