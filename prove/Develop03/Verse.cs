using System.Globalization;

class Verse
{
    private int _number;
    private string _text;

    public int Number
    {
        set
        {
            _number = value;
        }
        get
        {
            return _number;
        }
    }
    public string Text
    {
        set
        {
            _text = value;
        }
        get
        {
            return _text;
        }
    }
    public Verse(int number, string text)
    {
        this.Number = number;
        this.Text = text;
    }
}