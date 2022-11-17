namespace dtp15_todolist
{
    public class Todo
    {
        public static List<TodoItem> list = new List<TodoItem>();

        public const int Active = 1;
        public const int Waiting = 2;
        public const int Ready = 3;
        public static string StatusToString(int status)
        {
            switch (status)
            {
                case Active: return "aktiv";
                case Waiting: return "väntande";
                case Ready: return "avklarad";
                default: return "(felaktig)";
            }
        }
        public class TodoItem
        {
            public int status;
            public int priority;
            public string task;
            public string taskDescription;
            public TodoItem(int priority, string task)
            {
                this.status = Active;
                this.priority = priority;
                this.task = task;
                this.taskDescription = "";
            }
            public TodoItem(string todoLine)
            {
                string[] field = todoLine.Split('|');
                status = Int32.Parse(field[0]);
                priority = Int32.Parse(field[1]);
                task = field[2];
                taskDescription = field[3];
            }
            public void Print(bool verbose = false)
            {
                string statusString = StatusToString(status);
                Console.Write($"|{statusString,-12}|{priority,-6}|{task,-20}|");
                if (verbose)
                    Console.WriteLine($"{taskDescription,-40}|");
                else
                    Console.WriteLine();
            }

        }
        public static void ReadListFromFile()
        {
            string todoFileName = "todo.lis";
            Console.Write($"Läser från fil {todoFileName} ... ");
            StreamReader sr = new StreamReader(todoFileName);
            int numRead = 0;

            string line;
            while ((line = sr.ReadLine()) != null)
            {
                TodoItem item = new TodoItem(line);
                list.Add(item);
                numRead++;
            }
            sr.Close();
            Console.WriteLine($"Läste {numRead} rader.");
        }
        private static void PrintHeadOrFoot(bool head, bool verbose)
        {
            if (head)
            {
                Console.Write("|status      |prio  |namn                |");
                if (verbose) Console.WriteLine("beskrivning                             |");
                else Console.WriteLine();
            }
            Console.Write("|------------|------|--------------------|");
            if (verbose) Console.WriteLine("----------------------------------------|");
            else Console.WriteLine();
        }
        private static void PrintHead(bool verbose)
        {
            PrintHeadOrFoot(head: true, verbose);
        }
        private static void PrintFoot(bool verbose)
        {
            PrintHeadOrFoot(head: false, verbose);
        }
        public static void PrintTodoList(int x, bool verbose = false)
        {
            if (x == 1)
            {
                PrintHead(verbose);
                foreach (TodoItem item in list)
                {
                    if (item.status == 1)
                        item.Print(verbose);
                }
                PrintFoot(verbose);
            }
            else if (x == 2)
            {
                PrintHead(verbose);
                foreach (TodoItem item in list)
                {
                    item.Print(verbose);
                }
                PrintFoot(verbose);
            }
        }
        public static void PrintHelp()
        {
            Console.WriteLine("Kommandon:");
            Console.WriteLine("hjälp              lista denna hjälp");
            Console.WriteLine("ladda              laddar att-göra-listan");
            Console.WriteLine("spara              sparar att-göra-listan till laddad fil");
            Console.WriteLine("ny                 skapar en ny uppgift i att-göra-listan");
            Console.WriteLine("lista              lista att-göra-listan (Aktiva prio 1 uppgifter) ");
            Console.WriteLine("lista /allt        lista att-göra-listan (Aktiva uppgifter) ");
            Console.WriteLine("beskriv            lista att-göra-listan med beskrivning (Akiva prio 1 uppgifter) ");
            Console.WriteLine("beskriv /allt      lista att-göra-listan med beskrivning (Akiva prio 1 uppgifter) ");
            Console.WriteLine("aktivera /uppgift  ändrar status på önskad uppgift(uppgift = namn)");
            Console.WriteLine("vänta /uppgift     ändrar status på önskad uppgift(uppgift = namn) ");
            Console.WriteLine("klar /uppgift      ändrar status på önskad uppgift(uppgift = namn)");
            Console.WriteLine("sluta              spara att-göra-listan och sluta");
        }
        public static void NewItem()
        {
            string s = "1";
            Console.Write("Uppgiftens namn:> ");
            string namn = Console.ReadLine();
            Console.Write("Prioritet:> ");
            int prioritet = Int32.Parse(Console.ReadLine());
            Console.Write("Beskrivning:> ");
            string Beskrivning = Console.ReadLine();
            string line = $"{s}|{prioritet}|{namn}|{Beskrivning}";
            TodoItem item = new TodoItem(line);
            list.Add(item);
        }
        public static void SaveListToFile(string x)
        {
            string todoFileName = x;
            using (StreamWriter outfile = new StreamWriter(todoFileName))
            {
                foreach (TodoItem item in list)
                {
                    if (item != null)
                        outfile.WriteLine($"{item.status}|{item.priority}|{item.task}|{item.taskDescription}");
                }
            }
            Console.WriteLine($"Saving list to file {todoFileName}....");
        }
        public static void ChangeStatusOnItem(string x, int y)
        {
            foreach (TodoItem item in list)
            {
                if (item.task == x)
                {
                    item.status = y;
                }
            }
        }
        static public bool SetStatus(string rawCommand)
        {
            string command = rawCommand.Trim();
            if (command == "") return false;
            else
            {
                string[] cwords = command.Split(' ');
                if (cwords.Length < 3) return false;
                if (cwords[0] == "aktivera")
                {
                    string task = $"{cwords[1]} {cwords[2]}";
                    ChangeStatusOnItem(task, 1);
                }
                if (cwords[0] == "klar")
                {
                    string task = $"{cwords[1]} {cwords[2]}";
                    ChangeStatusOnItem(task, 3);
                }
                if (cwords[0] == "vänta")
                {
                    string task = $"{cwords[1]} {cwords[2]}";
                    ChangeStatusOnItem(task, 2);
                }
                return true;
            }
        }
        class MainClass
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Välkommen till att-göra-listan!");
                Todo.PrintHelp();
                string command;
                do
                {
                    command = MyIO.ReadCommand("> ");
                    if (MyIO.Equals(command, "hjälp"))
                        Todo.PrintHelp();
                    else if (MyIO.Equals(command, "ladda"))
                        Todo.ReadListFromFile();
                    else if (MyIO.Equals(command, "sluta"))
                    {
                        Console.WriteLine("Hej då!");
                        break;
                    }
                    else if (MyIO.Equals(command, "lista"))
                    {
                        if (MyIO.HasArgument(command, "allt"))
                            Todo.PrintTodoList(2, verbose: false);
                        else
                            Todo.PrintTodoList(1, verbose: false);
                    }
                    else if (MyIO.Equals(command, "beskriv"))
                    {
                        if (MyIO.HasArgument(command, "allt"))
                            Todo.PrintTodoList(2, verbose: true);
                        else
                            Todo.PrintTodoList(1, verbose: true);
                    }
                    else if (MyIO.Equals(command, "ny"))
                        Todo.NewItem();
                    else if (MyIO.Equals(command, "aktivera") || (MyIO.Equals(command, "klar") || (MyIO.Equals(command, "vänta"))))
                        Todo.SetStatus(command);
                    else if (MyIO.Equals(command, "spara"))
                        Todo.SaveListToFile("todoCopy.lis");
                    else
                        Console.WriteLine($"Okänt kommando: {command}");
                }
                while (true);
            }
        }
        class MyIO
        {
            static public string ReadCommand(string prompt)
            {
                Console.Write(prompt);
                return Console.ReadLine();
            }
            static public bool Equals(string rawCommand, string expected)
            {
                string command = rawCommand.Trim();
                if (command == "") return false;
                else
                {
                    string[] cwords = command.Split(' ');
                    if (cwords[0] == expected) return true;
                }
                return false;
            }
            static public bool HasArgument(string rawCommand, string expected)
            {
                string command = rawCommand.Trim();
                if (command == "") return false;
                else
                {
                    string[] cwords = command.Split(' ');
                    if (cwords.Length < 2) return false;
                    if (cwords[1] == expected) return true;
                }
                return false;
            }
        }
    }
}
     



