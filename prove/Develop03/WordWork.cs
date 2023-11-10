using System.Text.RegularExpressions;

partial class WordWork
{
    private bool _isHidden;
    private string _word;

   public WordWork(string text)
    {
        _isHidden = false;
        _word = text;
    }
    public string Word { set { _word = value; } get { return _word; } }
    public bool IsHidden { set { _isHidden = value; } get { return _isHidden; } }

    public string Print()
    {
        if (!IsHidden)
        {
            return Word;
        }
        else
        {
            return MyRegex().Replace(Word, "_");
        }
    }

    [GeneratedRegex(".")]
    private static partial Regex MyRegex();
}