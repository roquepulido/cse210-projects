class Circle : Shape
{
    private double _radius;
    public double Radius
    {
        get { return _radius; }
        set { _radius = value; }
    }

    public Circle(string color, double radius): base(color)
    {
        this.Radius = radius;
    }
    public override double GetArea()
    {
        return Math.PI * this.Radius * this.Radius;
    }

}