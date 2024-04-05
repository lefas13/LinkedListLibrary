using LinkedListLibrary;

class Program
{
    static LinkList<string> linkedList = new LinkList<string>();

    static void Main(string[] args)
    {
        // Добавляем записи
        linkedList.Add("Diamond");
        linkedList.Add("Iron");
        linkedList.Add("Copper");
        linkedList.Add("Mercury");
        linkedList.Add("Flint");
        linkedList.Add("Wood");

        while (true)
        {
            Console.WriteLine("\n                 Меню:");
            Console.WriteLine(" ________________________________________");
            Console.WriteLine("|       1. Добавить запись в список      |");
            Console.WriteLine("|       2. Удалить запись из списка      |");
            Console.WriteLine("|       3. Вывод количества записей      |");
            Console.WriteLine("|         4. Поиск записи в списке       |");
            Console.WriteLine("|           5. Очищение списка           |");
            Console.WriteLine("|          6. Вывести все записи         |");
            Console.WriteLine("|          7. Выйти из программы         |");
            Console.WriteLine("|________________________________________|\n");

            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddNode();
                    break;
                case "2":
                    RemoveNode();
                    break;
                case "3":
                    Console.WriteLine($"Количество записей в списке равно: {linkedList.Count}.");
                    break;
                case "4":
                    SearchNode();
                    break;
                case "5":
                    linkedList.Clear();
                    break;
                case "6":
                    PrintAllNodes();
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Неправильный выбор. Пожалуйста, введите число от 1 до 7.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddNode()
    {
        Console.Write("Введите значение для ячейки в списке: ");
        string value = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(value))
        {
            Console.WriteLine("Значение записи не может быть пустым.");
        }
        else 
        { 
            bool isAdd = false;
            while (!isAdd)
            {
                Console.Write("Введите 1 - Добавить в начало списка; 2 - Добавить в конец списка: ");
                string number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        linkedList.AppendFirst(value);
                        Console.WriteLine($"Запись \"{value}\" успешно добавлена в начало.");
                        isAdd = true;
                        break;
                    case "2":
                        linkedList.Add(value);
                        Console.WriteLine($"Запись \"{value}\" успешно добавлена в конец.");
                        isAdd = true;
                        break;
                     default:
                        Console.WriteLine("Вводимое значение не входит в выбор действия.");
                        break;
                }
            }
        }
    }

    static void RemoveNode()
    {
        Console.Write("Введите значение записи для удаления: ");
        string value = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(value))
        {
            if (linkedList.Remove(value))
                Console.WriteLine($"Запись \"{value}\" успешно удалена.");
            else
                Console.WriteLine($"Запись \"{value}\" не найдена в списке.");
        }
        else
        {
            Console.WriteLine("Значение записи не может быть пустым.");
        }
    }

    static void SearchNode()
    {
        Console.Write("Введите значение для поиска в списке: ");
        string node = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(node))
        {
            if (linkedList.Contains(node))
                Console.WriteLine($"Запись {node} есть в списке.");
            else
                Console.WriteLine($"Записи {node} нет в списке");
        }
        else
        {
            Console.WriteLine("Значения узлов не могут быть пустыми.");
        }
    }

    static void PrintAllNodes()
    {
        Console.WriteLine("Все записи в списке:");
        foreach (var node in linkedList)
        {
            Console.WriteLine(node);
        }
    }
}
