class LogEntry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Log { get; set; }

    public LogEntry()
    {
        Date = DateTime.Now.ToShortDateString();
        Prompt = "";
        Log = "";
    }
    public LogEntry(string prompt, string log)
    {
        Date = DateTime.Now.ToString();
        Prompt = prompt;
        Log = log;
    }
    public void PrintEntry()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Date: {Date}");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Prompt: {Prompt}");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Log: {Log}");
        Console.ResetColor();
        Console.WriteLine();
    }
}