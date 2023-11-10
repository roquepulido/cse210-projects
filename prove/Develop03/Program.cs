using System.Text.RegularExpressions;

partial class Program
{
    static string PrintMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer, choose an option:");
        Console.WriteLine("Select the book from you goint to select the scripture:");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("1. Book of Mormon");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("2. Old Testament");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("3. New Testament");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("4. Doctrine and Covenants");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("5. Pearl of Great Price");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("6. Exit");
        Console.ResetColor();
        Console.Write("Option selected (just number): ");
        return Console.ReadLine();
    }
    static void Main(string[] args)
    {
        CollectionScriptures baseCollectionScriptures = new();
        CollectionScriptures selectedCollection = new();
        bool keepPlaying = true;
        string option;
        string fileName = "scriptures.json";
        WorkingScripture workingScripture = new();
        baseCollectionScriptures.Load(fileName);

        while (keepPlaying)
        {
            option = PrintMenu();
            workingScripture.Clearlist();
            switch (option)
            {
                case "1":
                    selectedCollection.Scriptures = baseCollectionScriptures.GetByBook(1);
                    break;
                case "2":
                    selectedCollection.Scriptures = baseCollectionScriptures.GetByBook(2);
                    break;
                case "3":
                    selectedCollection.Scriptures = baseCollectionScriptures.GetByBook(3);
                    break;
                case "4":
                    selectedCollection.Scriptures = baseCollectionScriptures.GetByBook(4);
                    break;
                case "5":
                    selectedCollection.Scriptures = baseCollectionScriptures.GetByBook(5);
                    break;
                case "6":
                    keepPlaying = false;
                    break;
                default:
                    Console.WriteLine();
                    Console.Write("The option writed ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(option);
                    Console.ResetColor();
                    Console.WriteLine(" is not correct try again.");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
            if (option == "1" || option == "2" || option == "3" || option == "4" || option == "5")
            {
                option = selectedCollection.PrintScripturesAndGetIndex();
                if (MyRegex().IsMatch(option) && int.Parse(option) - 1 >= 0 && int.Parse(option) - 1 < selectedCollection.Scriptures.Count)
                {
                    workingScripture.SetVerses(selectedCollection.Scriptures[int.Parse(option) - 1].Verses);
                    workingScripture.Start();
                }
                else
                {
                    Console.WriteLine($"Here is not a scripture for the number {option}");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }


            }
        }
        Console.Clear();
        Console.WriteLine("Have a nice day.");
    }

    [GeneratedRegex("^[0-9]$")]
    private static partial Regex MyRegex();
}