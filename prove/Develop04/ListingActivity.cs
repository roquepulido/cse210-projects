class ListingActivity : Activity
{
    private int _count;
    public int Count
    {
        set { this._count = value; }
        get { return this._count; }
    }
    private List<string> _prompts;
    public List<string> Prompts
    {
        set { this._prompts = value; }
        get { return this._prompts; }
    }
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        this.Prompts = new List<string>
       {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"};
    }
    public void Run()
    {
        
        this.DisplayStartingMessage();
        this.DisplayPrompt();
        List<string> userList = this.GetListFromUser();
        Console.WriteLine();
        SlowPrintConsole.WriteLine($"You listed {userList.Count} times!");
        Console.WriteLine();
        this.DisplayEndingMessage();
    }
    public string GetRandomPrompt()
    {
        Random rnd = new();
        return this.Prompts[rnd.Next(this.Prompts.Count)];
    }
    public List<string> GetListFromUser()
    {
        List<string> userList = new();
        DateTime endTime = DateTime.Now.AddSeconds(this.Duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            userList.Add(Console.ReadLine());
        }
        return userList;
    }
    public void DisplayPrompt()
    {
        Console.Clear();
        SlowPrintConsole.WriteLine("Get Ready...");
        this.ShowSpinner(4);
        SlowPrintConsole.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine();
        SlowPrintConsole.WriteLine($"--- {this.GetRandomPrompt()} ---");
        Console.WriteLine();
        SlowPrintConsole.Write($"You may begin in: ");
        this.ShowCountDown(5);
        Console.WriteLine();
    }
}