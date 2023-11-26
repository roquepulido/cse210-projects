class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }
    public void Run()
    {
        DateTime endTime;

        
        this.DisplayStartingMessage();
        Console.Clear();
        SlowPrintConsole.WriteLine("Get Ready...");
        this.ShowSpinner(4);
        endTime = DateTime.Now.AddSeconds(this.Duration);
        while (DateTime.Now < endTime)
        {
            SlowPrintConsole.Write("Breathe in... ");
            this.ShowCountDown(5);
            SlowPrintConsole.Write("Now breathe out... ");
            this.ShowCountDown(5);
            Console.WriteLine();
        }
        this.DisplayEndingMessage();
    }
}