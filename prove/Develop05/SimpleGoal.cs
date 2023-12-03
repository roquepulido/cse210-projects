
using System.Text.Json;

class SimpleGoal : Goal
{
    private bool _isComplete;
    public bool Completed
    {
        get { return _isComplete; }
        set { _isComplete = value; }
    }
    public SimpleGoal():base(){}
    public SimpleGoal(string ShortName, string Description, int Points) : base(ShortName, Description, Points) { this.Completed = false; }
    public SimpleGoal(string ShortName, string Description, int Points, bool Completed) : base(ShortName, Description, Points) { this.Completed = Completed; }

    public override string GetJson()
    {
        return JsonSerializer.Serialize(this);
    }

    public override bool IsComplete()
    {
        return this.Completed;
    }

    public override int RecordEvent()
    {
        if (!this.IsComplete())
        {
            this.Completed = true;
            return this.Points;
        }
        return 0;
    }
    public override string GetDetailsString()
    {
        string check = "[ ]";
        if (this.Completed)
        {
            check = "[X]";
        }
        return $"{check} {base.GetDetailsString()}";
    }
}
