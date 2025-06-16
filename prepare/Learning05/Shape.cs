public abstract class Shape
{
    // private string _color;

    public Shape(string color)
    {
        Color = color;
    }

    public string Color{ get; set;}

    // public string GetColor()
    // {
    //     return _color;
    // }

    // public void Setcolor(string color)
    // {
    //     _color = color;
    // }

    public abstract double GetArea();
}