class SlowPrintConsole
{
    public static int Speed{get;set;}=100;
    public static void Write(string text)
    {
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(Speed);
        }
    }

    public static void WriteLine(string text)
    {
        Write(text);
        Console.WriteLine();
    }
}