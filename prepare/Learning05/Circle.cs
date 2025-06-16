public class Circle : Shape
{
    // private double _radius;

    public double Radius{ get; set;}
    public Circle(string color, double radius) : base(color)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }
}