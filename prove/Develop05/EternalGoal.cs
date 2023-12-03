using System.Text.Json;

class EternalGoal : Goal
{
    private int _timesDone;
    public int TimesDone
    {
        get { return _timesDone; }
        set { _timesDone = value; }
    }

    public EternalGoal() : base() { }
    public EternalGoal(string name, string description, int points) : base(name, description, points) { this.TimesDone = 0; }


    public override string GetJson()
    {
        return JsonSerializer.Serialize(this);
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override int RecordEvent()
    {
        this.TimesDone += 1;
        return this.Points;
    }
    public override string GetDetailsString()
    {
        return $"Times done: {this.TimesDone} - {base.GetDetailsString()}";
    }
}