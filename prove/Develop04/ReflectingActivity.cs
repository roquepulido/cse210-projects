using System.Text.RegularExpressions;

class ReflectingActivity : Activity
{
    private readonly Random rnd = new();
    private List<string> _prompts;
    public List<string> Prompts
    {
        set { this._prompts = value; }
        get { return this._prompts; }
    }
    private List<string> _questions;
    public List<string> Questions
    {
        set { this._questions = value; }
        get { return this._questions; }
    }

    public ReflectingActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience.\nThis will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        this.Prompts = new List<string>{
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
            };
        this.Questions = new List<string>{
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
            };
    }
    public void Run()
    {
        this.DisplayStartingMessage();
        this.DisplayPrompt();
        this.DisplayQuestions();
        this.DisplayEndingMessage();
    }
    public string GetRandomPrompt()
    {

        return this.Prompts[rnd.Next(this.Prompts.Count)];
    }
    public string GetRandomQuestion()
    {

        return this.Questions[rnd.Next(this.Questions.Count)];
    }
    public void DisplayPrompt()
    {

        Console.Clear();
        SlowPrintConsole.WriteLine("Get Ready...");
        this.ShowSpinner(4);
        SlowPrintConsole.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        SlowPrintConsole.WriteLine($"--- {this.GetRandomPrompt()} ---");
        Console.WriteLine();
        SlowPrintConsole.WriteLine($"When you have something in mind, press any key to continue.");
        Console.ReadKey();
        Console.Write("\b \b");
        Console.WriteLine();
        SlowPrintConsole.WriteLine($"Now ponder on each of the following questions as ther related to this experience.");
        SlowPrintConsole.Write($"You may begin in: ");
        this.ShowCountDown(5);
        Console.WriteLine();
    }
    public void DisplayQuestions()
    {
        DateTime initTime = DateTime.Now;
        DateTime endTime = DateTime.Now.AddSeconds(this.Duration);
        List<int> availableIndex = Enumerable.Range(0, this._questions.Count).ToList();
        int rndNum;
        while (DateTime.Now < endTime)
        {
            if (availableIndex.Count != 0)
            {
                rndNum = rnd.Next(availableIndex.Count);

                SlowPrintConsole.Write($"> {this.Questions[availableIndex[rndNum]]} ");
                availableIndex.RemoveAt(rndNum);
                this.ShowSpinner(4);
                Console.WriteLine();

            }else {
                SlowPrintConsole.WriteLine("You answered all the questions. Press any key to end.");
                Console.ReadKey();
                Console.Write("\b \b");
                endTime = DateTime.Now;
                TimeSpan timeSpan = new(endTime.Ticks-initTime.Ticks);
                base.Duration=(int)timeSpan.TotalSeconds;
            }
        }
    }
}