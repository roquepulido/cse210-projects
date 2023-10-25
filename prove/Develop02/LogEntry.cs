class LogEntry
{
    public string _date { get; set; }
    public string _prompt { get; set; }
    public string _log { get; set; }

    public LogEntry()
    {
        _date = DateTime.Now.ToShortDateString();
        _prompt = "";
        _log = "";
    }
    public LogEntry(string prompt, string log)
    {
        _date = DateTime.Now.ToString();
        _prompt = prompt;
        _log = log;
    }
    public void PrintEntry()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Date: {_date}");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Prompt: {_prompt}");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Log: {_log}");
        Console.ResetColor();
        Console.WriteLine();
    }
}