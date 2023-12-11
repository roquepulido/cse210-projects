
public class Notes
{
	private DateTime _date;
	public DateTime Date
	{
		get { return _date; }
		set { _date = value; }
	}
	private string _title;
	public string Title
	{
		get { return _title; }
		set { _title = value; }
	}

	private string _text;
	public string Text
	{
		get { return _text; }
		set { _text = value; }
	}
	public Notes()
	{
		this.Date = DateTime.Now;
		this.Title = "";
		this.Text = "";
	}

	public Notes(string text, string title, DateTime date)
	{
		this.Date = date;
		this.Text = text;
		this.Title = title;
	}

	public string GetNote()
	{
		return $"{this.Title}\n\n{this.Text}\n\n{this.Date}";
	}
}
