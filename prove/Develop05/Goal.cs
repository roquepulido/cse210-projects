

abstract class Goal
{    
    private int _idGoal;
    public int IdGoal
    {
        get { return _idGoal; }
        set { _idGoal = value; }
    }
    
    private string _shortName;
    public string ShortName
    {
        get { return _shortName; }
        set { _shortName = value; }
    }
    private string _description;
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    private int _points;
    public int Points
    {
        get { return _points; }
        set { _points = value; }
    }
    public Goal(){}
    protected Goal(string shortName, string description, int points)
    {
        this.ShortName = shortName;
        this.Description = description;
        this.Points = points;
        this.IdGoal = 0;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetJson();
    public virtual string  GetDetailsString()
    {
        return $"Name: {this.ShortName}, Points: {this.Points}\n--{this.Description}--";
    }

}
