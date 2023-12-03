using System.Text.Json;

class ChecklistGoal : Goal
{
    private int _amountCompleted;
    public int AmountCompleted
    {
        get { return _amountCompleted; }
        set { _amountCompleted = value; }
    }
    private int _target;
    public int Target
    {
        get { return _target; }
        set { _target = value; }
    }
    private int _bonus;
    public int Bonus
    {
        get { return _bonus; }
        set { _bonus = value; }
    }

    public ChecklistGoal() : base() { }
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        this.Target = target;
        this.Bonus = bonus;
        this.AmountCompleted = 0;
    }

    public override int RecordEvent()
    {
        if (this.AmountCompleted != this.Target)
        {
            int total = this.Points;
            this.AmountCompleted += 1;
            if (this.AmountCompleted == this.Target)
            {
                total += this.Bonus;
            }
            return total;
        }
        return 0;
    }

    public override bool IsComplete()
    {
        if (this.AmountCompleted == this.Target) return true;
        else return false;
    }
    public override string GetDetailsString()
    {
        string check = "[ ]";
        if (this.IsComplete())
        {
            check = "[X]";
        }
        return $"{check} - Times completed {this.AmountCompleted}/{this.Target} {base.GetDetailsString()} ";
    }
    public override string GetJson()
    {
        return JsonSerializer.Serialize(this);
    }

}