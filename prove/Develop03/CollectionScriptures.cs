using System.Data;
using System.Text.Json;

class CollectionScriptures
{
    private List<Scripture> _collectionScriptures = new();

    public List<Scripture> Scriptures
    {
        get { return _collectionScriptures; }
        set { _collectionScriptures = value; }
    }
    public void Load(string fileName)
    {
        string json = File.ReadAllText(fileName);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Scriptures loaded.");
        Console.ResetColor();
        Console.WriteLine($"Press enter to continue...");
        Console.ReadLine();
        this.Scriptures = JsonSerializer.Deserialize<List<Scripture>>(json);
    }
    public void Save(string fileName)
    {
        File.WriteAllText(fileName, JsonSerializer.Serialize(this.Scriptures));
    }

    public void PrintCollection()
    {
        Console.Clear();
        Console.WriteLine($"Count of scriptures {this.Scriptures.Count}");
        Console.WriteLine();
        foreach (Scripture scripture in _collectionScriptures)
        {
            Console.WriteLine($"Book: {scripture.Book}");
            if (scripture.Verses.Count == 1)
            {
                Console.WriteLine($"{scripture.SubBook} {scripture.Chapter}:{scripture.Verses[0].Number}");
            }
            else
            {
                Console.WriteLine($"{scripture.SubBook} {scripture.Chapter}:{scripture.Verses[0].Number}-{scripture.Verses[^1].Number}");
            }
            foreach (Verse verse in scripture.Verses)
            {
                Console.WriteLine($"\x1b[1m{verse.Number}\x1b[0m {verse.Text}");
            }
            Console.WriteLine();
        }
    }

    public List<Scripture> GetByBook(int bookNumber)
    {
        string book;

        switch (bookNumber)
        {
            case 1: // Book of mormon
                book = "Book of Mormon";
                break;
            case 2:
                book = "Old Testament";
                break;
            case 3:
                book = "New Testament";
                break;
            case 4:
                book = "Doctrine and Covenants";
                break;
            case 5:
                book = "Pearl of Great Price";
                break;
            default:
                return new();
        }
        return _collectionScriptures.FindAll(
            delegate (Scripture scripture)
            {
                return scripture.Book == book;
            }
        );

    }


}