class Rectangle : Shape
{
    private double _length;
    public double Length
    {
        get { return _length; }
        set { _length = value; }
    }

    public Rectangle(string color, double length, double width) : base(color)
    {
        this.Length = length;
        this.Width = width;

    }
    private double _width;
    public double Width
    {
        get { return _width; }
        set { _width = value; }
    }
    public override double GetArea()
    {
        return this.Length * this.Width;
    }
}