public class Course
{
	private string _name;
	public string Name
	{
		get { return _name; }
		set { _name = value; }
	}

	private string _description;
	public string Description
	{
		get { return _description; }
		set { _description = value; }
	}

	private string _season;
	public string Season
	{
		get { return _season; }
		set { _season = value; }
	}
	private int _year;
	public int Year
	{
		get { return _year; }
		set { _year = value; }
	}

	private List<Notes> _notes;
	public List<Notes> Notes
	{
		get { return _notes; }
		set { _notes = value; }
	}
	private List<Assignment> _assignments;
	public List<Assignment> Assignments
	{
		get { return _assignments; }
		set { _assignments = value; }
	}

	public Course()
	{
		throw new NotImplementedException();
	}

	public Course(string name, string desc, string season, int year, List<Notes> notes, List<Assignment> assignaments)
	{
		throw new NotImplementedException();
	}

	public void PrintCourse()
	{
		throw new NotImplementedException();
	}

	public void PrintDeadlines()
	{
		throw new NotImplementedException();
	}

	public void PrintGrades()
	{
		throw new NotImplementedException();
	}
}

