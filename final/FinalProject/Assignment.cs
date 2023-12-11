
public class Assignment
{
	private string _title;
	public string Title
	{
		get { return _title; }
		set { _title = value; }
	}

	private string _description;
	public string Description
	{
		get { return _description; }
		set { _description = value; }
	}
	private DateTime _deadline;
	public DateTime Deadline
	{
		get { return _deadline; }
		set { _deadline = value; }
	}
	private int _grade;
	public int Grade
	{
		get { return _grade; }
		set { _grade = value; }
	}

	public Assignment()
	{
		this.Title = "";
		this.Description = "";
		this.Deadline = DateTime.Now;
		this.Grade = 0;
	}
	public Assignment(string title, string desc, DateTime deadline, int grade)
	{
		this.Title = title;
		this.Description = desc;
		this.Deadline = deadline;
		this.Grade = grade;
	}

	public string GetAssignment()
	{
		throw new NotImplementedException();
	}

	public int DaysUntilDeadline()
	{
		return (int)this.Deadline.Subtract(DateTime.Now).TotalDays;
	}
}

