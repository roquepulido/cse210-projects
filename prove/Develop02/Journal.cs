
using System.Text.Json;

class Journal
{
    public string Owner { get; set; }
    public string BirthDate { get; set; }
    public List<LogEntry> LogEntries { get; set; } = new List<LogEntry>();
    public Journal LoadJournal(string fileName)
    {
        if (fileName == "") fileName = "log.json"; else fileName += ".json";
        string json = File.ReadAllText(fileName);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Journal with the name {fileName} loaded.");
        Console.ResetColor();
        Console.WriteLine($"Press any key to continue...");
        Console.ReadLine();
        return JsonSerializer.Deserialize<Journal>(json);

    }
    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }
    public void SaveJournal(string fileName)
    {
        if (fileName == "") fileName = "log.json"; else fileName += ".json";
        File.WriteAllText(fileName, this.ToJson());
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Journal saved with the name {fileName}");
        Console.ResetColor();
        Console.WriteLine($"Press any key to continue...");
        Console.ReadLine();

    }
    public void PrintJournal()
    {
        Console.WriteLine($"This log owner is {Owner}.");
        for (int i = 0; i < LogEntries.Count; i++)
        {
            LogEntries[i].PrintEntry();
            Console.WriteLine($"-------- Entry {i + 1} of {LogEntries.Count} ----------");
            Console.WriteLine($"-------- Press any key for next log ----------");
            Console.ReadLine();
        }
        Console.WriteLine("End of log entries.");
        Console.WriteLine();
    }

}