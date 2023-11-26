class Activity
{
    private string _name;

    public string Name
    {
        set { this._name = value; }
        get { return this._name; }
    }
    private string _description;

    public string Description
    {
        set { this._description = value; }
        get { return this._description; }
    }
    private int _duration;
    public int Duration
    {
        set { this._duration = value; }
        get { return this._duration; }
    }
        
    public Activity(string name, string description)
    {
        this.Name = name;
        this.Description = description;
        this.Duration = 0;
    }
    public void DisplayStartingMessage()
    {
        string timeLetter = "";
        int time = 0;
        Console.Clear();

        SlowPrintConsole.WriteLine($"Activity: {this.Name}");
        Console.WriteLine();
        SlowPrintConsole.WriteLine($"Description: {this.Description}");
        Console.WriteLine();
        SlowPrintConsole.WriteLine("How long, in seconds, would you like for your session? ");

        timeLetter = Console.ReadLine();

        while (!int.TryParse(timeLetter, out time))
        {
            SlowPrintConsole.WriteLine($"The option {timeLetter} is not a number try again.");
            SlowPrintConsole.WriteLine("How long estimate, in seconds, would you like for your session? ");

            timeLetter = Console.ReadLine();

        }

        this.Duration = time;
    }
    public void DisplayEndingMessage()
    {
        SlowPrintConsole.WriteLine("Well done");
        this.ShowSpinner(5);
        SlowPrintConsole.WriteLine($"You have completed {this.Duration} seconds of the {this.Name}");
        this.ShowSpinner(5);
    }
    public void ShowSpinner(int seconds, int speed = 250)
    {

        foreach (var i in Enumerable.Range(0, seconds))
        {
            Console.Write("|");
            Thread.Sleep(speed);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(speed);
            Console.Write("\b \b");
            Console.Write("─");
            Thread.Sleep(speed);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(speed);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
    public void ShowCountDown(int seconds)
    {

        foreach (var i in Enumerable.Range(1, seconds))
        {
            Console.Write(seconds + 1 - i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

}