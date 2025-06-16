using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square1 = new Square("Green", 4);
        shapes.Add(square1);

        Rectangle rectangle1 = new Rectangle("Orange", 9, 4);
        shapes.Add(rectangle1);

        Circle circle1 = new Circle("Purple", 4);
        shapes.Add(circle1);

        foreach (Shape s in shapes)
        {
            string color = s.Color;
            double area = s.GetArea();

            Console.WriteLine($"The {color} {s} has an area of {area}");
        }
    }
}