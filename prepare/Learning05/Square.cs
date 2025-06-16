using System.Runtime.CompilerServices;

public class Square : Shape
{
    // private double _side;

    public double Side { get; set;}

    public Square(string color, double side) : base(color)
    {
        Side = side;
    }

    public override double GetArea()
    {
        return Side * Side;
    }

}