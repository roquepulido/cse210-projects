public class BachelorDegree
{
	private string _name;
	public string Name
	{
		get { return _name; }
		set { _name = value; }
	}
	private DateTime _initDateTime;
	public DateTime InitDateTime
	{
		get { return _initDateTime; }
		set { _initDateTime = value; }
	}
	private DateTime _estimatedEnd;
	public DateTime EstimatedEnd
	{
		get { return _estimatedEnd; }
		set { _estimatedEnd = value; }
	}
	private List<Course> _courses;
	public List<Course> Courses
	{
		get { return _courses; }
		set { _courses = value; }
	}

	public BachelorDegree()
	{
		throw new NotImplementedException();
	}

	public BachelorDegree(string name, DateTime init, DateTime end, List<Course> courses)
	{
		throw new NotImplementedException();
	}

	public void PrintBachelorDegree()
	{
		throw new NotImplementedException();
	}

	public void PrintDeadlines(string courseName)
	{
		throw new NotImplementedException();
	}

	public void PrintGrades(string courseName)
	{
		throw new NotImplementedException();
	}
}
