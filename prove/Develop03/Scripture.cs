class Scripture
{
    private string _book;
    private string _subBook;
    private int _chapter;
    private List<Verse> _verses;
    public string Book
    {
        set { _book = value; }
        get { return _book; }
    }
    public string SubBook
    {
        set { _subBook = value; }
        get { return _subBook; }
    }
    public int Chapter
    {
        set { _chapter = value; }
        get { return _chapter; }
    }
    public List<Verse> Verses
    {
        set { _verses = value; }
        get { return _verses; }
    }
    public Scripture()
    {
        this.Book = "book";
        this.SubBook = "subBook";
        this.Chapter = 0;
        this.Verses = new();
    }
    public Scripture(string book, string subBook, int chapter, List<Verse> verses)
    {
        this.Book = book;
        this.SubBook = subBook;
        this.Chapter = chapter;
        this.Verses = verses;

    }

}