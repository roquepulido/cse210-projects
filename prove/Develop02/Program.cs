using System.Reflection.Metadata;

class Program
{
    static List<string> prompsList = new() { "Who was the most interesting person I interacted with today?", "What was the best part of my day?", "How did I see the hand of the Lord in my life today?", "What was the strongest emotion I felt today?", "If I had one thing I could do over today, what would it be?" };
    static public int GetMenu()
    {

        int optNum;
        string number;
        Console.Clear();
        Console.WriteLine("Please select one of the following choises: ");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Exit");
        Console.Write("What would you like to do ? ");
        number = Console.ReadLine();

        if (number == "1"
        || number == "2"
        || number == "3"
        || number == "4"
        || number == "5")
        {
            optNum = int.Parse(number);
            return optNum;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Choise invalid try again...");
            Console.ResetColor();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            return GetMenu();
        }




    }

    static void Main(string[] args)
    {
        bool keepRunning = true;
        int choise;
        Journal journal = new();

        Console.WriteLine("Welcome to my Journal App!");
        while (keepRunning)
        {
            choise = GetMenu();
            string prompt, log;
            Random rnd = new();
            switch (choise)
            {
                case 1: // Write

                    prompt = prompsList[rnd.Next(prompsList.Count)];

                    Console.Write("Prompt: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(prompt);
                    Console.ResetColor();
                    Console.WriteLine("Log:");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    log = Console.ReadLine();
                    Console.ResetColor();
                    journal.LogEntries.Add(new LogEntry(prompt, log));
                    break;
                case 2: // Display
                    Console.WriteLine("");
                    journal.PrintJournal();
                    break;
                case 3: // Load
                    Console.WriteLine("For load the file, write the file name of leave blank for the default name(log)");
                    journal = journal.LoadJournal(Console.ReadLine());
                    break;
                case 4: // Save
                    if (journal.Owner == null)
                    {
                        Console.WriteLine("Please enter the name of the owner of this log: ");
                        journal.Owner = Console.ReadLine();
                    }
                    Console.WriteLine("For save the file, write the file name of leave blank for the default name(log)");
                    journal.SaveJournal(Console.ReadLine());
                    break;
                case 5: // Quit
                    keepRunning = false;
                    break;
            }
            Console.WriteLine(choise);

        }
    }
}