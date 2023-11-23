class Assignment
{
    private string _studentName;
    public string StudentName
    {
        set { this._studentName = value; }
        get { return this._studentName; }
    }
    private string _topic;

    public string Topic
    {
        set { this._topic = value; }
        get { return this._topic; }
    }

    public Assignment(string studentName, string topic)
    {
        this._studentName = studentName;
        this._topic = topic;
    }

    public string GetSummary()
    {
        return $"{this._studentName} - {this._topic}";
    }



}