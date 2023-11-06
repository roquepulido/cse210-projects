using System.Text.Json;

class Program
{
    static string PrintMenu()
    {
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
        Console.Write("Option Selected (just number): ");
        return Console.ReadLine();
    }
    static void Main(string[] args)
    {
        CollectionScriptures collectionScriptures = new();
        bool keepPlaying = true;
        string option;
        string fileName = "scriptures.json";
        CollectionScriptures newcol = new();

        collectionScriptures.Load(fileName);

        while (keepPlaying)
        {
            option = PrintMenu();
            switch (option)
            {
                case "1":
                    newcol.Scriptures=collectionScriptures.GetByBook(1);
                    break;
                case "2":
                    newcol.Scriptures=collectionScriptures.GetByBook(2);
                    break;
                case "3":
                    newcol.Scriptures=collectionScriptures.GetByBook(3);
                    break;
                case "4":
                    newcol.Scriptures=collectionScriptures.GetByBook(4);
                    break;
                case "5":
                   newcol.Scriptures=collectionScriptures.GetByBook(5);
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
        }
        Console.Clear();
        Console.WriteLine("Have a nice day.");
    }
}