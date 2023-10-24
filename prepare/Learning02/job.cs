public class Job
{
    public string _company, _jobTitle;
    public int _startYear, _endYear;
    public Job(
        string company, string jobTitle, int startYear, int endYear
    )
    {
        this._company = company;
        this._jobTitle = jobTitle;
        this._startYear = startYear;
        this._endYear = endYear;
    }
    public void Display()
    {
        Console.WriteLine($"{this._jobTitle} ({this._company}) {this._startYear}-{this._endYear}");
    }
}