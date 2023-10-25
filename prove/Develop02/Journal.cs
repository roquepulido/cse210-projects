
using System.Text.Json;

class Journal
{
    public string _owner { get; set; }
    public string _birthDate { get; set; }
    public List<LogEntry> _logEntries { get; set; } = new List<LogEntry>();
    public Journal LoadJournal(string fileName)
    {
        if (fileName == "") fileName = "log.json"; else fileName += ".json";
        string json = File.ReadAllText(fileName);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Journal with the name {fileName} loaded.");
        Console.ResetColor();
        Console.WriteLine($"Press enter to continue...");
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
        Console.WriteLine($"Press enter to continue...");
        Console.ReadLine();

    }
    public void PrintJournal()
    {
        if (_logEntries.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No entries.");
            Console.WriteLine();
            Console.ResetColor();
            Console.ReadLine();
        }
        else
        {

            Console.WriteLine($"This log owner is {_owner}.");
            for (int i = 0; i < _logEntries.Count; i++)
            {
                _logEntries[i].PrintEntry();
                Console.WriteLine($"-------- Entry {i + 1} of {_logEntries.Count} ----------");
                Console.WriteLine($"-------- Press enter for next log ----------");
                Console.ReadLine();
            }
            Console.WriteLine("End of log entries.");
            Console.WriteLine();
        }
    }

}