
public class FileInfo
{
	private string _path;
	public string Path
	{
		get { return _path; }
		set { _path = value; }
	}
	private string _fileName;
	public string FileName
	{
		get { return _fileName; }
		set { _fileName = value; }
	}

	private BachelorDegree _bachelorDegree;
	public BachelorDegree BachelorDegree
	{
		get { return _bachelorDegree; }
		set { _bachelorDegree = value; }
	}


	public FileInfo()
	{
		this.Path = "";
		this.FileName = "new_file";
		this.BachelorDegree = new BachelorDegree();
	}

	public FileInfo(string path, string fileName, BachelorDegree degree)
	{
		this.Path = path;
		this.FileName = fileName;
		this.BachelorDegree = degree;
	}
}

