

class TableGoal
{
    public int Id { get; set; }
    public string GoalJson { get; set; }
    public int GoalType { get; set; }
    public TableGoal(int id, string goalJson, int goalType)
    {
        this.Id = id;
        this.GoalJson = goalJson;
        this.GoalType = goalType;
    }

    public TableGoal(object id, object goalJson, object goalType)
    {
        this.Id = (int)id;
        this.GoalJson = (string)goalJson;
        this.GoalType = (int)goalType;
    }
}