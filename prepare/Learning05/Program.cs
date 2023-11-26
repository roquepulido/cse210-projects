using System.Diagnostics;
/// 
/// Practice the principle of polymorphism by writing a program that computes the areas of different shapes cut out of pieces of paper.
/// 
/// For all shapes, you need to keep track of the color of the paper and then have a method to compute the area. The area should not be stored as a member variable, but instead, you should store the length of the shapes sides and then compute the area as needed.
/// 
/// Your program should include squares (which store a color and a single side), rectangles (which store a color and two sides), and a circle (which store a color and a radius). You should create several kinds of shapes and put them into a single list. Then, iterate through the list and display their areas.
///
class Program
{
    static void Main(string[] args)
    {
        Square square = new("red", 4);
        Rectangle rectangle = new("blue", 4, 2);
        Circle circle = new("purple", 4);
        List<Shape> shapes = new()
        {
            square,
            rectangle,
            circle
        };

        Debug.Assert(square.GetColor() == "red");
        Debug.Assert(square.GetArea() == 16);
        Debug.Assert(rectangle.GetColor() == "blue");
        Debug.Assert(rectangle.GetArea() == 8);
        Debug.Assert(circle.GetColor() == "purple");
        Debug.Assert(circle.GetArea() == Math.PI * 16);


        shapes.ForEach(s =>
        {
            System.Console.Write("Shape: ");
            System.Console.WriteLine(s.GetType());
            System.Console.Write("Color: ");
            System.Console.WriteLine(s.GetColor());
            System.Console.Write("Area: ");
            System.Console.WriteLine("{0:N2}", s.GetArea());
            System.Console.WriteLine();
        });
    }
}