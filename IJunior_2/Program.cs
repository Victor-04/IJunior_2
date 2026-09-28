using System.Reflection;

namespace main_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Находим все классы, реализующие ITask
            var taskTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(ITask).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .ToList();

            if (taskTypes.Count == 0)
            {
                Console.WriteLine("Нет доступных заданий. Добавьте хотя бы один класс с реализацией ITask.");
                return;
            }

            // Главный цикл программы
            while (true)
            {
                Console.Clear();
                int selectedIndex = ShowMenuAndGetChoice(taskTypes);

                // Если пользователь нажал Escape – выходим
                if (selectedIndex == -1)
                    break;

                // Запускаем выбранное задание
                Type selectedType = taskTypes[selectedIndex];
                ITask? task = Activator.CreateInstance(selectedType) as ITask;

                if (task is null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[Ошибка] Не удалось создать экземпляр {selectedType.Name}.");
                    Console.ResetColor();

                    Console.WriteLine("\nНажмите Enter, чтобы вернуться к списку заданий.");
                    Console.ReadLine();
                    continue;
                }

                try
                {
                    task.Run();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n[Ошибка выполнения] {ex.Message}");
                    Console.ResetColor();
                }

                // Предложение вернуться или выйти
                Console.WriteLine("\nНажмите Enter, чтобы вернуться к списку заданий.");
                Console.WriteLine("Нажмите Esc, чтобы выйти из программы.");

                while (true)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Enter)
                    {
                        break; // возвращаемся в главный цикл
                    }
                    else if (key == ConsoleKey.Escape)
                    {
                        return; // выход из программы
                    }
                    // Игнорируем другие клавиши
                }
            }
        }

        /// <summary>
        /// Отображает список заданий с возможностью выбора стрелочками.
        /// Возвращает индекс выбранного элемента или -1 при нажатии Escape.
        /// </summary>
        static int ShowMenuAndGetChoice(List<Type> taskTypes)
        {
            int current = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine("=== Выберите задание (↑/↓ для навигации, Enter – запуск, Esc – выход) ===\n");

                for (int i = 0; i < taskTypes.Count; i++)
                {
                    if (i == current)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($" > {taskTypes[i].Name}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"   {taskTypes[i].Name}");
                    }
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                    current = (current - 1 + taskTypes.Count) % taskTypes.Count;
                else if (key == ConsoleKey.DownArrow)
                    current = (current + 1) % taskTypes.Count;
                else if (key == ConsoleKey.Escape)
                    return -1;

            } while (key != ConsoleKey.Enter);

            return current;
        }
    }
}