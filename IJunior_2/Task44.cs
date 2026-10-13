namespace main_1
{
    public class Task44 : ITask
    {
        private (int id, string firstName, string lastName, string middleName, int positionId)[] employees = { };
        private (int id, string positionName)[] positions = { };

        private const string CompactView = "compact";

        public void Run()
        {
            bool isRunning = true;

            employees = new (int id, string firstName, string lastName, string middleName, int positionId)[]
            {
                (1, "Иван",  "Иванов",   "Иванович", 1),
                (2, "Пётр",  "Петров",   "Петрович", 2),
                (3, "Анна",  "Петровна", "Сидорова", 3),
            };
            positions = new (int id, string positionName)[] {
                (1, "Разработчик"),
                (2, "Тестировщик"),
                (3, "Менеджер"),
            };

            Console.Clear();

            while (isRunning)
            {
                PrintListCommands();
                Console.Write("Enter command:");
                string command = Console.ReadLine() ?? "";

                switch (command.Trim())
                {
                    case "1":
                        AddDossier();
                        break;
                    case "2":
                        PrintAllDossiers(CompactView);
                        break;
                    case "3":
                        RemoveDossier();
                        break;
                    case "4":
                        FindDossiersByLastName();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("\nInvalid command.\n");
                        break;
                }
            }

            Console.WriteLine("\nExiting the program.");
        }

        private void PrintListCommands()
        {
            Console.WriteLine("-== Dossier Manager ==-\n");
            Console.WriteLine("  1. Add dossier");
            Console.WriteLine("  2. Print all dossiers");
            Console.WriteLine("  3. Remove dossier");
            Console.WriteLine("  4. Find by last name");
            Console.WriteLine("  5. Exit\n");
        }

        private string GetPositionName(int positionId)
        {
            foreach (var pos in positions)
            {
                if (pos.id == positionId)
                    return pos.positionName;
            }
            return "Unknown";
        }

        private bool AddDossier()
        {
            Console.Clear();
            string firstName = "";
            string middleName = "";
            string lastName = "";
            string addPosition = "n";
            int positionId = 0;
            int employeeId = 0;

            Console.Write("Enter first name: ");
            firstName = Console.ReadLine() ?? "";

            Console.Write("Enter middle name: ");
            middleName = Console.ReadLine() ?? "";

            Console.Write("Enter last name: ");
            lastName = Console.ReadLine() ?? "";

            Console.Write("Add new position? (y/n): ");
            addPosition = Console.ReadLine() ?? "n";
            
            if (addPosition.ToLower() == "y")
            {
                Console.Write("Enter new position name: ");
                string newPositionName = Console.ReadLine() ?? "";
                if (newPositionName == "")
                {
                    Console.WriteLine("Position name cannot be empty.");
                    return false;
                }
                positionId = positions.Length == 0 ? 1 : positions.Max(p => p.id) + 1;
                positions = positions.Concat(new (int id, string positionName)[] { (positionId, newPositionName) }).ToArray();
            }
            else
            {
                foreach (var position in positions)
                {
                    Console.WriteLine($"ID: {position.id}, Position: {position.positionName}");
                }

                Console.Write("\nEnter existing position ID: ");
                positionId = int.TryParse(Console.ReadLine(), out positionId) ? positionId : 0;

                if (!positions.Any(p => p.id == positionId))
                {
                    Console.WriteLine($"Position with ID {positionId} not found.");
                    return false;
                }
            }

            employeeId = employees.Length == 0 ? 1 : employees.Max(e => e.id) + 1;
            employees = employees.Concat(new (int id, string firstName, string lastName, string middleName, int positionId)[] { (employeeId, firstName, lastName, middleName, positionId) }).ToArray();
            Console.Clear();
            Console.WriteLine("Employee added successfully.\n");

            return true;
        }

        private void PrintAllDossiers(string view = CompactView)
        {
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - -");

            for (int i = 0; i < employees.Length; i++)
            {
                var e = employees[i];
                string positionName = GetPositionName(e.positionId);

                if (view == CompactView)
                {
                    Console.WriteLine($"{i + 1} - {e.lastName} {e.firstName} {e.middleName} - {positionName}");
                }
                else
                {
                    Console.WriteLine($"ID: {e.id} | {i + 1} - {e.lastName} {e.firstName} {e.middleName} - {positionName}");
                }
            }

            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - -\n");
        }

        private bool RemoveDossier()
        {
            Console.Clear();
            PrintAllDossiers();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - -\n");
            Console.Write("Enter the ID of the employee to remove: ");
            int id = int.TryParse(Console.ReadLine(), out int employeeId) ? employeeId : 0;

            if (id == 0)
            {
                Console.WriteLine("Invalid employee ID.");
                return false;
            }

            if (!employees.Any(e => e.id == id))
            {
                Console.WriteLine($"Employee with ID {id} not found.");
                return false;
            }

            employees = employees.Where(e => e.id != id).ToArray();
            Console.Clear();
            Console.WriteLine("Employee removed successfully.\n");

            return true;
        }

        private bool FindDossiersByLastName()
        {
            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - - - -");

            Console.Write("Enter last name to search: ");
            string query = Console.ReadLine() ?? "";

            var found = new (int id, string firstName, string lastName, string middleName, int positionId)[0];

            foreach (var employee in employees)
            {
                if (employee.lastName.Contains(query, StringComparison.OrdinalIgnoreCase))
                {
                    var extended = new (int id, string firstName, string lastName, string middleName, int positionId)[found.Length + 1];
                    for (int i = 0; i < found.Length; i++)
                    {
                        extended[i] = found[i];
                    }
                    extended[found.Length] = employee;
                    found = extended;
                }
            }

            if (found.Length == 0)
            {
                Console.WriteLine($"No employees found with last name '{query}'.");
                Console.WriteLine();
                return false;
            }

            Console.WriteLine($"Found {found.Length} employee(s) with last name '{query}':");

            for (int i = 0; i < found.Length; i++)
            {
                var e = found[i];
                string positionName = GetPositionName(e.positionId);
                Console.WriteLine($"{i + 1} - {e.lastName} {e.firstName} {e.middleName} - {positionName}");
            }

            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - -\n");

            return true;
        }
    }
}