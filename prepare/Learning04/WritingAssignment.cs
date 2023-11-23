class WritingAssignment : Assignment
{
    private string _title;
    public WritingAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {
        this._title = title;
    }

    public string GetWrithingInformation()
    {
        return this._title;
    }
}