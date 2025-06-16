using System.Drawing;

public class Rectangle : Shape
{
//     private double _length;
//     private double _width;

    public double Length {get; set;}

    public double Width{get; set;}

    public Rectangle(string color, double length, double width) : base(color)
    {
        Length = length;
        Width = width;
    }

    public override double GetArea()
    {
        return Length * Width;
    }
}