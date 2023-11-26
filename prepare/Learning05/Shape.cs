class Shape
{
    private string _color;
    public string Color
    {
        get { return _color; }
        set { _color = value; }
    }
    public string GetColor() { return this.Color; }
    public void SetColor(string value) { this.Color = value; }

    public Shape(string color)
    {
        this.Color = color;
    }

    public virtual double GetArea() { return 0; }

}